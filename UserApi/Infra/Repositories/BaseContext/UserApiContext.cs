using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserApi.Domain.Entities;

namespace UserApi.Infra.Repositories.BaseContext
{
    public class UserApiContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserApiContext(DbContextOptions<UserApiContext> opt) : base(opt) { }

        public DbSet<UserModel> User { get; set; }
    }
}
