namespace App.Common.Data
{
    using System;
    using System.Collections.Generic;

    public delegate void OnContextSaveChange(IDbContext context);
    public class DbContext : IDbContext
    {
        private IList<OnContextSaveChange> saveChangeEvents;
        public DbContext()
        {
            this.saveChangeEvents = new List<OnContextSaveChange>();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void RegisterSaveChangeEvent(OnContextSaveChange ev)
        {
            this.saveChangeEvents.Add(ev);
        }

        public virtual void OnSaveChanged()
        {
            foreach (OnContextSaveChange ev in this.saveChangeEvents)
            {
                ev(this);
            }
        }

        public virtual IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity<System.Guid>
        {
            throw new NotImplementedException();
        }
    }
}