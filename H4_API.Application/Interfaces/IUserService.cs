using H4_API.Application.Base;
using H4_API.Domain.Model;
using System.Threading.Tasks;

namespace H4_API.Application.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> GetUserDetails(string username, string password);
    }
}