using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UserApi.Domain.Dtos.Request.Login;
using UserApi.Domain.Entities;
using UserApi.Infra.Repositories;

namespace UserApi.Services
{
    public class LoginService
    {
        private LoginRepository _loginRepository;
        private TokenRepository _tokenRepository;

        public LoginService(LoginRepository loginRepository, TokenRepository tokenRepository)
        {
            _loginRepository = loginRepository;
            _tokenRepository = tokenRepository;
        }

        public Result LoginUser(LoginRequestDTO loginRequestDTO)
        {
            Task<SignInResult> resultIdentity = _loginRepository.LoginUser(loginRequestDTO);

            if (resultIdentity.Result.Succeeded)
            {
                IdentityUser<int> identityUser = _loginRepository.IdentityUserReturn(loginRequestDTO);
                TokenModel token = _tokenRepository.CreateToken(identityUser);

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou");
        }
    }
}
