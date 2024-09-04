using Microsoft.AspNetCore.Mvc;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1/server")]
    public class ServerController : ControllerBase
    {
        private readonly ILogger<ServerController> _logger;

        public ServerController(ILogger<ServerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateServer()
        {

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServerById(Guid id)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllServers()
        {
            return Ok();
        }
        [HttpPost("{id}/start")]
        public async Task<IActionResult> StartServer(Guid id)
        {
            return NoContent();
        }
        [HttpPost("{id}/stop")]
        public async Task<IActionResult> StopServer(Guid id)
        {
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServer(Guid id)
        {
            return NoContent();
        }

    }
}
