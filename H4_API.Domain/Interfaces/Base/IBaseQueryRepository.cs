using System.Linq;

namespace H4_API.Domain.Interfaces.Base
{
    public interface IBaseQueryRepository<TValue> : IBaseRepository<TValue>
    {
        IQueryable<TValue> ListQuery();
    }
}