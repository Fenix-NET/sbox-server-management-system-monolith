using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Dtos.Identity;
using SboxServersManager.Application.Interfaces.Identity;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest userRegistration)
        {
            var result = await _authenticationService.RegisterUserAsync(userRegistration);

            if (!result.Succeeded)
                return BadRequest(ModelState);

            return StatusCode(201);
        }

        [HttpPost]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginRequest user)
        {
            if (!await _authenticationService.ValidateUser(user)) return Unauthorized();

            var tokenDto = await _authenticationService.CreateToken(populateExp: true); 
            
            return Ok(tokenDto);
        }
    }
}
