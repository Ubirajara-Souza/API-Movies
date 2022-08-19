using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace UserApi.Infra.Repositories
{
    public class LogoutRepository
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutRepository(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Task LogoutUser()
        {
            Task resultIdentity = _signInManager.SignOutAsync();

            return resultIdentity;
        }
    }
}
