using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;

namespace LaBestiaNet.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetUser>> Register(UserRegister userRegister);
        Task<ServiceResponse<GetUser>> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
