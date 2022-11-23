using AutoMapper;
using LaBestiaNet.Data;
using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;
using Microsoft.EntityFrameworkCore;

namespace LaBestiaNet.Services.UserService
{

    public class UserService : IUserService

         
    {
        public readonly IMapper mapper;
        private readonly DataContext context;
        public UserService(IMapper mapper,DataContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<ServiceResponse<User>> addUser(User user)
        {
            try
            {
               await context.Users.AddAsync(user);
                return new ServiceResponse<User>(true, user, "Done");
            }catch(Exception ex)
            {
                return new ServiceResponse<User>(false, null, ex.Message);
            }
        }

        public async  Task<ServiceResponse<List<GetUser>>> getCompatibleUsers(UserPreferences filter)
        {
            try
            {
                List<User> users = await context.Users.Where(user => (user.Weight <= filter.MaxWeight || filter.MaxWeight.Equals(null))
                                                                  && (user.Weight >= filter.MinWeight || filter.MinWeight.Equals(null)))
                                                      .Where(user => (user.Height <= filter.MaxHeight || filter.MaxHeight.Equals(null))
                                                                  && (user.Height >= filter.MinHeight || filter.MinHeight.Equals(null)))
                                                      .Where(user => (user.Age <= filter.MaxAge || filter.MaxAge.Equals(null))
                                                                  && (user.Age >= filter.MinAge || filter.MinAge.Equals(null)))
                                                      .ToListAsync();
                List<GetUser> result = users.Select(user=> mapper.Map<GetUser>(user)).ToList();
                                                           
                return new ServiceResponse<List<GetUser>>(true, result, "Daselo todo papa");
            }
            catch(Exception ex)
            {
                return new ServiceResponse<List<GetUser>>(false, null, ex.Message);
            }

         
        }

        public Task<ServiceResponse<User>> getUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<User>> getUserByName()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<User>>> getUsers()
        {
            List<User> dbUsers = await context.Users.ToListAsync();
            return new ServiceResponse<List<User>>(true, dbUsers, "Pa ti mi cola");
        }
    }
}
