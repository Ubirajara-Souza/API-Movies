using UserApi.Infra.Repositories.BaseContext;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UserApi.Domain.Dtos.Request.User;

namespace UserApi.Infra.Repositories
{
    public class UserRepository
    {
        protected readonly UserApiContext _context;
        private UserManager<IdentityUser<int>> _userManager;

        public UserRepository(UserApiContext context, UserManager<IdentityUser<int>> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Task<IdentityResult> AddUser(IdentityUser<int> userIdentity, UserDTO userDTO)
        {
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(userIdentity, userDTO.Password);

            return resultIdentity;
        }

        public Task<string> GenerateEmailConfirmationToken(IdentityUser<int> userIdentity)
        {
            Task<string> token = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
            return token;
        }

        public IdentityResult ActiveAccountUser(ActiveAccountUserDTO activeAccountUserDTO)
        {
            IdentityUser<int> identityUser = _userManager.Users.FirstOrDefault(u => u.Id == activeAccountUserDTO.UserID);
            IdentityResult resultIdentity = _userManager.ConfirmEmailAsync(identityUser, activeAccountUserDTO.ActivationCode).Result;

            return resultIdentity;
        }

        public IdentityResult CreateRoleUserResult (IdentityUser<int> userIdentity)
        {
            IdentityResult roleUserResult = _userManager.AddToRoleAsync(userIdentity, "simple").Result;

            return roleUserResult;
        }



    }
}
