namespace App.Common.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity<System.Guid>;
        int SaveChanges();
        void RegisterSaveChangeEvent(OnContextSaveChange ev);
        void OnSaveChanged();
    }
}