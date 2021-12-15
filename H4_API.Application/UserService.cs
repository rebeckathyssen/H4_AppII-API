using H4_API.Application.Base;
using H4_API.Application.Interfaces;
using H4_API.Domain.Interfaces;
using H4_API.Domain.Model;
using System.Threading.Tasks;

namespace H4_API.Application
{
    public class UserService : BaseService<User, IUserRepository>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUserDetails(string username, string password)
        {
            return await _repository.GetUserDetails(username, password);
        }
    }
}