using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Domain.Dtos.Request.Login;
using UserApi.Domain.Dtos.Request.User;

namespace UserApi.Infra.Repositories
{
    public class LoginRepository
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginRepository(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }
        public Task<SignInResult> LoginUser(LoginRequestDTO loginRequestDTO)
        {
            Task<SignInResult> resultIdentity = _signInManager
                .PasswordSignInAsync(loginRequestDTO.UserName, loginRequestDTO.Password, false, false);

            return resultIdentity;
        }

        public IdentityUser<int> IdentityUserReturn(LoginRequestDTO loginRequestDTO)
        {
            IdentityUser<int> identityUser = _signInManager.UserManager.Users
                .FirstOrDefault(user => user.NormalizedUserName == loginRequestDTO.UserName.ToUpper());

            return identityUser;
        }

        public IdentityUser<int> RequestResetPasswordUser(ResetPasswordUserRequestDTO resetPasswordUserRequestDTO)
        {
            IdentityUser<int> identityUser = RecoverEmailUser(resetPasswordUserRequestDTO.Email);

            return identityUser;
        }

        public IdentityResult ResetPasswordUser(ConfirmResetUserRequestDTO confirmResetUserRequestDTO)
        {
            IdentityUser<int> identityUser = RecoverEmailUser(confirmResetUserRequestDTO.Email);

            IdentityResult identityResult = _signInManager.UserManager
                .ResetPasswordAsync(identityUser, confirmResetUserRequestDTO.Token, confirmResetUserRequestDTO.Password).Result;

            return identityResult;
        }

        private IdentityUser<int> RecoverEmailUser(string email)
        {
            return _signInManager.UserManager.Users
                 .FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());
        }
    }
}

