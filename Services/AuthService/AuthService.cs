using AutoMapper;
using LaBestiaNet.Data;
using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;
using Microsoft.EntityFrameworkCore;

namespace LaBestiaNet.Services.AuthService
{
    public class AuthService : IAuthService

    {
        public readonly DataContext context;
        private IMapper mapper;

        public AuthService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();

        }

        public async Task<ServiceResponse<User>> Register(UserRegister userRegister)
        {
            User user = mapper.Map<User>(userRegister);

            try
            {
                if (!await UserExist(userRegister.UserName))
                {
                    CreatePasswordHash(userRegister.Password, out byte[] passHash, out byte[] passSalt);
                   
                    user.PassHash = passHash;
                    user.PassSalt = passSalt;
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                    return new ServiceResponse<User>(true, user, "User added");
                }
                else
                {
                    return new ServiceResponse<User>(false, null, "Username already exist");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<User>(false, null, ex.Message);
            }
        }

        public async Task<bool> UserExist(string username)
        {
            return await context.Users.AnyAsync(user => user.UserName.ToLower() == username.ToLower());

        }

        private void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
