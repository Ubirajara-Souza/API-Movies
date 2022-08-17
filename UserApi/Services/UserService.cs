using AutoMapper;
using UserApi.Domain.Dtos.Response;
using UserApi.Domain.Dtos.Request.User;
using UserApi.Domain.Entities;
using UserApi.Infra.Repositories;
using Microsoft.AspNetCore.Identity;
using FluentResults;
using System.Threading.Tasks;

namespace UserApi.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Result AddUser(UserDTO userDTO)
        {
            UserModel User = _mapper.Map<UserModel>(userDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(User);

            Task<IdentityResult> resultIdentity = _userRepository.AddUser(userIdentity, userDTO);

            if (resultIdentity.Result.Succeeded)
                return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public UserViews ListUserById(int id)
        {
            UserModel User = _userRepository.ListUserById(id);
            if (User != null)
            {
                UserViews userViews = _mapper.Map<UserViews>(User);
                return userViews;
            }
            return null;
        }
    }
}
