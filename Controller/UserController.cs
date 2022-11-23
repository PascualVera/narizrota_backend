using LaBestiaNet.Models;
using LaBestiaNet.Services.UserService;
using Microsoft.AspNetCore.Mvc;
namespace LaBestiaNet.Controller
{
    [ApiController]
    [Route("api/")]
    public class UserController : ControllerBase
    {
        public IUserService service { get; }
        public UserController(IUserService UserService)
        {
            service = UserService;
        }

        [HttpGet("user/all")]

        public async Task<ActionResult<ServiceResponse<List<User>>>> getAll()
        {
            return Ok(await service.getUsers());
        }

        [HttpPost("user/add")]
        public async Task<ActionResult<ServiceResponse<User>>> addUser(User user)
        {
            return Ok( await service.addUser(user));
        }
        [HttpPost("user/filter")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> filterUser(UserPreferences filter)
        {
            return Ok(await service.getCompatibleUsers(filter));
        }
    }
}
