using System.Threading;
using System.Threading.Tasks;
using H4_API.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace H4_API.Infrastructure.Interfaces
{
    public interface IDatabaseContext
    {
        void Dispose();
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Entry(object entity);
        string ToString();
        //Tables
        DbSet<User> Users { get; set; }
    }
}