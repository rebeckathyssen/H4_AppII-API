using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using H4_API.Core;
using H4_API.Domain.Interfaces.Base;

namespace H4_API.Application.Base
{
    public abstract class BaseService<TValue, TRepository> : IBaseService<TValue> where TRepository : IBaseRepository<TValue>
        where TValue : class, IEntity, new()
    {
        protected TRepository Repository;

        protected BaseService(TRepository repository)
        {
            this.Repository = repository;
        }

        public virtual async Task<TValue> Create(TValue value)
        {
            await Repository.Create(value);
            return value;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            return await Repository.Delete(id);
        }

        public virtual async Task<TValue> Get(Guid id)
        {
            return await Repository.Get(id);
        }

        public virtual async Task<IEnumerable<TValue>> List()
        {
            return await Repository.List();
        }

        public TValue Update(TValue value)
        {
            Repository.Update(value);
            return value;
        }
    }
}