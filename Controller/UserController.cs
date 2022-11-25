using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;
using LaBestiaNet.Services.UserService;
using Microsoft.AspNetCore.Mvc;
namespace LaBestiaNet.Controller
{
    [Route("api/")]
    [ApiController]
 
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
            ServiceResponse<List<User>> res = await service.getUsers();
            if (res.ok)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
            
        }
        [HttpPost("user/filter")]
        public async Task<ActionResult<ServiceResponse<List<GetUser>>>> filterUser(UserPreferences filter)
        {
            ServiceResponse<List<GetUser>> res = await service.getCompatibleUsers(filter);
            if (res.ok) {
                return Ok(res); 
            } else {
                return BadRequest(res); 
            }
       
        }
    }
}
