using UserApi.Domain.Entities;
using UserApi.Infra.Repositories.BaseContext;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UserApi.Domain.Dtos.Request.User;
using FluentResults;

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

        public UserModel ListUserById(int id)
        {
            UserModel user = _context.User.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
