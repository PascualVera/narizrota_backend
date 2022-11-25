using AutoMapper;
using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;
using LaBestiaNet.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaBestiaNet.Controller
{
    [Route("api/")]
    [ApiController]

 
    public class AuthController : ControllerBase
    {
        public IAuthService service { get; }
        

        public AuthController(IAuthService service)
        {
            this.service = service; 
           
        }


        [HttpPost("/auth/register")]
        public async Task<ActionResult<ServiceResponse<GetUser>>> Register(UserRegister registerUser)
        {   

            
            ServiceResponse<GetUser> res = await service.Register(registerUser);
            if (res.ok)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPost("/auth/login")]
        public async Task<ActionResult<ServiceResponse<GetUser>>> Login(UserLogin user)
        {

            ServiceResponse<GetUser> res = await service.Login(user.UserName, user.Password);
            if (res.ok)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
