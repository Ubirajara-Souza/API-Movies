using AutoMapper;
using UserApi.Domain.Dtos.Request.User;
using UserApi.Domain.Entities;
using UserApi.Infra.Repositories;
using Microsoft.AspNetCore.Identity;
using FluentResults;
using System.Threading.Tasks;
using System.Web;

namespace UserApi.Services
{
    public class UserService
    {
        private UserRepository _userRepository;
        private EmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, EmailRepository emailRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public Result AddUser(UserDTO userDTO)
        {
            UserModel User = _mapper.Map<UserModel>(userDTO);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(User);

            Task<IdentityResult> resultIdentity = _userRepository.AddUser(userIdentity, userDTO);

            if (resultIdentity.Result.Succeeded)
            {
                IdentityResult roleUserResult = _userRepository.CreateRoleUserResult(userIdentity);

                if (roleUserResult.Succeeded)
                {
                    string token = _userRepository.GenerateEmailConfirmationToken(userIdentity).Result;
                    var encodedCode = HttpUtility.UrlEncode(token);
                    _emailRepository.SubmitEmail(new[]
                    {
                        userIdentity.Email
                    },
                        "Link de Ativação", userIdentity.Id, token
                    );

                    return Result.Ok().WithSuccess(token);
                }
                return Result.Fail("Falha ao criar o tipo de perfil do usuário");
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result ActiveAccountUser(ActiveAccountUserDTO activeAccountUserDTO)
        {
            IdentityResult resultIdentity = _userRepository.ActiveAccountUser(activeAccountUserDTO);
            if (resultIdentity.Succeeded)
                return Result.Ok();

            return Result.Fail("Falha ao ativar conta de usuário");
        }
    }
}
