using MongoDB.Bson;

namespace App.Common.Data.MongoDB
{
    public interface IMongoDbContext : IDbContext
    {
        //IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity<System.Guid>;
        void Save<TEntity>(TEntity item) where TEntity : class;
        void Delete<TEntity>(ObjectId id);
        //IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity<System.Guid>;
    }
}
