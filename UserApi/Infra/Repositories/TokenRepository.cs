using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserApi.Domain.Entities;

namespace UserApi.Infra.Repositories
{
    public class TokenRepository
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public TokenRepository(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }
        public TokenModel CreateToken(IdentityUser<int> user)
        {
            Claim[] rightsUser = new Claim[]
            {
                new Claim("userName", user.UserName),
                new Claim("Id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")
                );
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: rightsUser,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenModel(tokenString);

        }

        public string GeneratePasswordResetToken(IdentityUser<int> identityUser)
        {
            string tokenRecovery = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

            return tokenRecovery;
        }
    }
}

