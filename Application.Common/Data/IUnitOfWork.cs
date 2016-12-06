namespace App.Common.Data
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get; }
        void Commit();
    }
}