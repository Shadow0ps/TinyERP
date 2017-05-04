namespace App.Common.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> GetDbSet<TEntity, TId>() where TEntity : class, IBaseEntity<TId>;
        int SaveChanges();
        void RegisterSaveChangeEvent(OnContextSaveChange ev);
        void OnSaveChanged();
    }
}