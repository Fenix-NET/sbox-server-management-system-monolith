using SboxServersManager.Application.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Identity.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {

        }
        public string GenerateRefreshToken()
        {

        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {

        }
    }
}
