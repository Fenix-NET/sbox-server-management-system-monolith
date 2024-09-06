using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Dtos.Identity;
using SboxServersManager.Application.Interfaces.Identity;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public TokenController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _authenticationService.RefreshToken(tokenDto);
                
            return Ok(tokenDtoToReturn);
        }
    }

}
