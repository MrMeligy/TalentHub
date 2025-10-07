using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Contracts
{
    public interface IAuthService
    {
        public string GenerateToken(Account user);
        public bool Verify(string password, string hashedpassword);
    }
}
