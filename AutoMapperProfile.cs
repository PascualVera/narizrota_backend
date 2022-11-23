using AutoMapper;
using LaBestiaNet.Dtos.User;
using LaBestiaNet.Models;

namespace LaBestiaNet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUser>();
        }
    }
}
