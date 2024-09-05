using Microsoft.AspNetCore.Identity;
using SboxServersManager.Application.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Identity
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationRequest userRegistrationRequest);
        Task<bool> ValidateUser(UserLoginRequest userAuthRequest); 
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<string> AuthenticateUserAsync(UserLoginRequest userAuthRequest);
    }
}
