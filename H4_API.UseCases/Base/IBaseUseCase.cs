using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H4_API.UseCases.Base
{
    public interface IBaseUseCase<TValue>
    {
        Task<TValue> Get(Guid id);
        Task<IEnumerable<TValue>> List();
        Task<TValue> Create(TValue value);
        TValue Create();
        Task<TValue> Update(TValue value);
        Task<bool> Delete(Guid id);
    }
}