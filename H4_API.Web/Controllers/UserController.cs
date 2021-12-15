using H4_API.Domain.Model;
using H4_API.UseCases;
using H4_API.UseCases.Base;
using H4_API.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace H4_API.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        private readonly UserUseCase _userUseCase;

        public UserController(UserUseCase useCase) : base(useCase)
        {
            _userUseCase = useCase;
        }

        [HttpGet]
        [Route("username={username}/password={password}")]
        public async Task<IActionResult> GetUserDetails(string username, string password)
        {
            var user = await _userUseCase.GetUserDetails(username, password);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}