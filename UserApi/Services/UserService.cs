using AutoMapper;
using UserApi.Domain.Dtos.Response;
using UserApi.Domain.Dtos.Request.User;
using UserApi.Domain.Entities;
using UserApi.Infra.Repositories;

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

        public UserViews AddUser(UserDTO userDTO)
        {
            UserModel User = _mapper.Map<UserModel>(userDTO);
            _userRepository.AddUser(User);

            return _mapper.Map<UserViews>(User);
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
