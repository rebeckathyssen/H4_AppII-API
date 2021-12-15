using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H4_API.Domain.Interfaces.Base
{
    public interface IBaseRepository<TValue>
    {
        Task<TValue> Get(Guid id);
        Task<IEnumerable<TValue>> List();
        Task<TValue> Create(TValue value);
        TValue Update(TValue value);
        Task<bool> Delete(Guid id);
    }
}