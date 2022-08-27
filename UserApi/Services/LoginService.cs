using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UserApi.Domain.Dtos.Request.Login;
using UserApi.Domain.Dtos.Request.User;
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
                string role = _loginRepository.GetRolesUser(identityUser);
                TokenModel token = _tokenRepository.CreateToken(identityUser, role);

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou");
        }

        public Result RequestResetPasswordUser(ResetPasswordUserRequestDTO resetPasswordUserRequestDTO)
        {
            IdentityUser<int> identityUser = _loginRepository.RequestResetPasswordUser(resetPasswordUserRequestDTO);

            if (identityUser != null)
            {
                string tokenRecovery = _tokenRepository.GeneratePasswordResetToken(identityUser);

                return Result.Ok().WithSuccess(tokenRecovery);
            }

            return Result.Fail("Falha ao solicitar redefinição");
        }

        public Result ResetPasswordUser(ConfirmResetUserRequestDTO confirmResetUserRequestDTO)
        {
            IdentityResult identityResult = _loginRepository.ResetPasswordUser(confirmResetUserRequestDTO);
            if (identityResult.Succeeded)
                return Result.Ok().WithSuccess("Senha redefinida com sucesso!");

            return Result.Fail("Houve um erro na operação");
        }
    }
}
