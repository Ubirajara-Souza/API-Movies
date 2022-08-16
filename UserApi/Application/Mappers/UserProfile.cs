using AutoMapper;
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
            CreateMap<UserModel, UserViews>();
        }
    }
}
