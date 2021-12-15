using H4_API.Application.Interfaces;
using H4_API.Core;
using H4_API.Domain.Model;
using H4_API.UseCases.Base;
using System.Threading.Tasks;

namespace H4_API.UseCases
{
    public class UserUseCase : BaseUseCase<User, IUserService>
    {
        private readonly IUserService _service;

        public UserUseCase(IUserService service, IUnitOfWork unitOfWork) : base(service, unitOfWork)
        {
            _service = service;
        }

        public async Task<User> GetUserDetails(string username, string password)
        {
            return await _service.GetUserDetails(username, password);
        }
    }
}