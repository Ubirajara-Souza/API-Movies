using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserApi.Domain.Dtos.Request.User;
using UserApi.Domain.Dtos.Response;
using UserApi.Domain.Entities;

namespace UserApi.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, UserModel>();
            CreateMap<UserModel, IdentityUser<int>>();
            CreateMap<UserModel, UserViews>();
        }
    }
}
