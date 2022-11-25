using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;

namespace LaBestiaNet.Services.UserService
{
    public interface IUserService
    {

        public Task<ServiceResponse<List<User>>> getUsers();
      
      
        public Task<ServiceResponse<List<GetUser>>> getCompatibleUsers(UserPreferences filter);
       

    }
}
