using AutoMapper;
using LaBestiaNet.Data;
using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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


        //Controller Services
        public async Task<ServiceResponse<GetUser>> Login(string username, string password)
        {
            try {
                User user = await context.Users.FirstOrDefaultAsync(user => user.UserName.ToLower() == username.ToLower());
                if(user == null)
                {
                    return new ServiceResponse<GetUser>(false, null, "user not found");
                }
                else if (!VerifyPasswordHash(password, user.PassHash, user.PassSalt))
                {
                    return new ServiceResponse<GetUser>(false, null, "password incorrect");
                }
                else
                {
                    GetUser loggeduser = mapper.Map<GetUser>(user);
                    return new ServiceResponse<GetUser>(true, loggeduser, "login succesfully");
                }
            }
            catch(Exception ex) {
                return new ServiceResponse<GetUser>(false, null, ex.Message);
            }

        }

        public async Task<ServiceResponse<GetUser>> Register(UserRegister userRegister)
        {
            User user = mapper.Map<User>(userRegister);

            try
            {
                if (!await UserExist(userRegister.UserName, userRegister.Email))
                {
                    CreatePasswordHash(userRegister.Password, out byte[] passHash, out byte[] passSalt);
                   
                    user.PassHash = passHash;
                    user.PassSalt = passSalt;
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();

                    return new ServiceResponse<GetUser>(true, mapper.Map<GetUser>(user), "User added");
                }
                else
                {
                    return new ServiceResponse<GetUser>(false, null, "Username or email already exist");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetUser>(false, null, ex.Message);
            }
        }

        //Encrypt and verification methods

        public async Task<bool> UserExist(string username, string email)
        {
            return await context.Users.AnyAsync(user => user.UserName.ToLower() == username.ToLower() || user.Email.ToLower()  == email);

        }

        private void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        private bool VerifyPasswordHash(string password, byte[] passHash, byte[] passSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(passSalt))
            {
               byte[] computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passHash);
            }

        }

    }
}
