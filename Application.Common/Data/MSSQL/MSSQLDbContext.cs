namespace App.Common.Data.MSSQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MSSQLDbContext : System.Data.Entity.DbContext, IMSSQLDbContext
    {
        private IList<OnContextSaveChange> saveChangeEvents;
        private System.Data.Entity.DbContext context;
        protected IOMode Mode { get; private set; }
        public MSSQLDbContext(IConnectionString connection, IOMode mode = IOMode.Read) : base(connection.ToString())
        {
            this.Mode = mode;
            this.saveChangeEvents = new List<OnContextSaveChange>();
            this.context = this;
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

        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity<System.Guid>
        {
            IDbSet<TEntity> dbset = new App.Common.Data.MSSQL.MSSQLDbSet<TEntity>(this, this.context, this.Mode);
            return dbset;
        }
    }
}