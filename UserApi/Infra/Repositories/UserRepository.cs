using UserApi.Domain.Entities;
using UserApi.Infra.Repositories.BaseContext;
using System.Linq;

namespace UserApi.Infra.Repositories
{
    public class UserRepository
    {
        protected readonly UserApiContext _context;

        public UserRepository(UserApiContext context)
        {
            _context = context;
        }

        public UserModel AddUser(UserModel user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return user;
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
