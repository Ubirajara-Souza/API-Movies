using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Domain.Dtos.Request.Login;

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
    }
}

