using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string IAuthService.GenerateToken(Account user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.AcademyId.ToString()??"Admin"));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration["JWT:Issuer"],
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            var _token = new JwtSecurityTokenHandler().WriteToken(token);
            return _token;
        }

        bool IAuthService.Verify(string password, string hashedpassword)
        {
            return (BCrypt.Net.BCrypt.Verify(password, hashedpassword));
        }
    }
}
