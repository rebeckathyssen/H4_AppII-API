using System;
using System.Threading;
using System.Threading.Tasks;
using H4_API.Core;
using H4_API.Infrastructure.Interfaces;

namespace H4_API.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _databaseContext;
        private bool _disposed = false;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Commit()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            try
            {
                await _databaseContext.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _databaseContext?.Dispose();
            }

            _disposed = true;
        }

    }
}