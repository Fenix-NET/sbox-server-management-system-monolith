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
        Task<IdentityResult> RegisterUserAsync(UserRegistrationRequest request);
        Task<string> AuthenticateUserAsync(UserLoginRequest request);
    }
}
