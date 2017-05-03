namespace App.Common.Data.MongoDB
{
    using System.Linq;
    using System.Collections.Generic;
    using global::MongoDB.Kennedy;

    public class MongoDbContext : ConcurrentDataContext, IMongoDbContext
    {
        private IList<OnContextSaveChange> saveChangeEvents;
        public MongoDbContext(IConnectionString connection)
            : base(connection.Database, connection.Server, connection.Port)
        {
        }
        public MongoDbContext() : this(new MongoConnectionString()) { }
        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity<System.Guid>
        {
            IQueryable<TEntity> collection = this.GetCollection<TEntity>();
            IDbSet<TEntity> dbset = new MongoDbSet<TEntity>(this, collection);
            return dbset;
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
