using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SboxServersManager.Application.Dtos.Identity;
using SboxServersManager.Application.Interfaces.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SboxServersManager.Infrastructure.Identity.Services
{
    /// <summary>
    /// Сервис управления пользователями, ответственный за регистрацию, создание JWT токенов.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        /// <summary>
        /// Регситрация нового пользователя
        /// </summary>
        /// <param name="request">Модель данных, необходимых для регистрации.</param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email,
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            return result;
        }

        public async Task<string> AuthenticateUserAsync(UserLoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                throw new UnauthorizedAccessException("Неверный email или пароль");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var expiresInMinutes = int.Parse(jwtSettings["ExpiresInMinutes"]);

            //[ClaimTypes.Name] = user.UserName,
            //[ClaimTypes.Email] = user.Email,
            //[ClaimTypes.Sid] = user.Id.ToString(),
            //[ClaimTypes.Role] = string.Join(",", _userManager.GetRolesAsync(user).Result),

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(",", _userManager.GetRolesAsync(user).Result)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

    }
}
