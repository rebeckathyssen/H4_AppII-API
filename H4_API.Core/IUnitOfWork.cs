using System.Threading.Tasks;

namespace H4_API.Core
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}