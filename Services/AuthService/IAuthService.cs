using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;

namespace LaBestiaNet.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<User>> Register(UserRegister userRegister);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
