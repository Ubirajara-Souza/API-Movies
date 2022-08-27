using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace UserApi.Infra.Repositories.BaseContext
{
    public class UserApiContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UserApiContext(DbContextOptions<UserApiContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            admin.PasswordHash = hasher.HashPassword(admin,
                _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN" }
            );

            builder.Entity<IdentityRole<int>>().HasData(
               new IdentityRole<int> { Id = 99998, Name = "simple", NormalizedName = "SIMPLE" }
           );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
                );
        }
    }
}
