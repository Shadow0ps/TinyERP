namespace App.Common.Data
{
    public abstract class BaseQueryRepository<TEntity> : BaseRepository<TEntity> where TEntity : class, IBaseEntity<System.Guid>
    {
        public BaseQueryRepository(App.Common.Data.MongoDB.IMongoDbContext context) : base(context)
        {
            this.DbSet = context.GetDbSet<TEntity>();
        }
    }
}
