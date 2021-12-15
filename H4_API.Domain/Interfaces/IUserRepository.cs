using H4_API.Domain.Interfaces.Base;
using H4_API.Domain.Model;
using System.Threading.Tasks;

namespace H4_API.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserDetails(string username, string password);
    }
}