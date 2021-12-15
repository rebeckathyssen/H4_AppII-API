using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H4_API.Core;
using H4_API.Domain.Interfaces.Base;
using H4_API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace H4_API.Infrastructure.Repository.Base
{
    public class BaseRepository<TValue> : IBaseQueryRepository<TValue> where TValue : class, IEntity, new()
    {
        private readonly IDatabaseContext _databaseContext;
        protected readonly DbSet<TValue> DbSet;

        protected BaseRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            DbSet = databaseContext.Set<TValue>();
        }

        public virtual async Task<TValue> Create(TValue value)
        {
            await DbSet.AddAsync(value);
            return value;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = await Get(id);

            if (entity == null) return false;

            var entityState = DbSet.Attach(entity);
            entityState.State = EntityState.Deleted;

            DbSet.Remove(entity);

            return true;
        }

        public virtual async Task<TValue> Get(Guid id)
        {
            try
            {
                return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public virtual async Task<IEnumerable<TValue>> List()
        {
            return await ListQuery().ToListAsync();
        }

        public virtual IQueryable<TValue> ListQuery()
        {
            return DbSet.AsNoTracking();
        }

        public virtual TValue Update(TValue value)
        {
            var entity = DbSet.Attach(value);

            DbSet.Update(value);
            entity.State = EntityState.Modified;

            return value;
        }
    }
}