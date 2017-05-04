namespace App.Common.Data.MongoDB
{
    using global::MongoDB.Bson;
    using System.Linq;
    public class MongoDbSet<TEntity> : DbSet<TEntity> where TEntity : class, IBaseEntity<System.Guid>
    {
        public IQueryable<TEntity> Collection { get; protected set; }
        public new IMongoDbContext Context { get; protected set; }

        public MongoDbSet(IMongoDbContext mongoDbContext, IQueryable<TEntity> collection)
        {
            this.Context = mongoDbContext;
            this.Collection = collection;
            //this.Context.RegisterSaveChangeEvent(this.OnContextSaveChange);
        }

        public override void Add(TEntity item)
        {
            this.Context.Save(item);
        }
        public override void Delete(string id)
        {
            ObjectId itemId = new ObjectId(id);
            this.Context.Delete<TEntity>(itemId);
        }

        public override TEntity Get(string id, string includes = "")
        {
            //ObjectId itemId = new ObjectId(id.Replace("-", ""));
            //return this.Collection.FirstOrDefault();
            return this.Collection.Where(item => item.Id.ToString() == id).FirstOrDefault();
        }

        public override void Update(TEntity item)
        {
            this.Context.Save(item);
        }
        public override void OnContextSaveChange(IDbContext context)
        {
        }
        public override IQueryable<TEntity> AsQueryable(string include = "")
        {
            return this.Collection;
        }
    }
}
