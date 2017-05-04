namespace App.Common.Data.MongoDB
{
    using System.Linq;
    using System.Collections.Generic;
    using global::MongoDB.Kennedy;
    using global::MongoDB.Bson;

    public class MongoDbContext : ConcurrentDataContext, IMongoDbContext
    {
        private IList<OnContextSaveChange> saveChangeEvents;
        public MongoDbContext(IConnectionString connection)
            : base(connection.Database, connection.Server, connection.Port)
        {
        }
        public MongoDbContext() : this(new MongoConnectionString()) { }
        public IDbSet<TEntity, TId> GetDbSet<TEntity, TId>() where TEntity : class, IBaseEntity<TId>
        {
            IQueryable<TEntity> collection = this.GetCollection<TEntity>();
            IDbSet<TEntity, TId> dbset = new MongoDbSet<TEntity, TId>(this, collection);
            return dbset;
        }

        public void Save<TEntity>(TEntity item) where TEntity : class
        {
            base.Save(item);
        }
        public void Delete<TEntity, TId>(TId id)
        {
            ObjectId itemId = new ObjectId(id.ToString());
            base.Delete<TEntity>(itemId);
        }

        public int SaveChanges()
        {
            return 0;
            //throw new NotImplementedException();
        }

        public void RegisterSaveChangeEvent(OnContextSaveChange ev)
        {
            this.saveChangeEvents.Add(ev);
        }

        public void OnSaveChanged()
        {
            foreach (OnContextSaveChange ev in this.saveChangeEvents)
            {
                ev(this);
            }
        }
    }
}
