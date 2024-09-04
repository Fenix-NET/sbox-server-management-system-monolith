using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Dtos.Request;
using SboxServersManager.Application.Interfaces;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1/server")]
    public class ServerController : ControllerBase
    {
        private readonly ILogger<ServerController> _logger;
        private readonly IServerManagementService _serverManagement;

        public ServerController(ILogger<ServerController> logger, IServerManagementService serverManagement)
        {
            _logger = logger;
            _serverManagement = serverManagement;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateServer([FromBody]CreateServerRequest serverRequest)
        {
            if (serverRequest == null) return BadRequest();

            try
            {
                var newServerId = await _serverManagement.CreateServerAsync(serverRequest);

                return CreatedAtAction(nameof(GetServerById), value: new { id = newServerId });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServerById(Guid id)
        {
            try
            {
                var server = await _serverManagement.GetServerAsync(id);

                return Ok(server);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllServers()
        {
            try
            {
                var servers = await _serverManagement.GetAllServersAsync();

                return Ok(servers);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("{id}/start")]
        public async Task<IActionResult> StartServer(Guid id)
        {
            try
            {
                await _serverManagement.StartServerAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("{id}/stop")]
        public async Task<IActionResult> StopServer(Guid id)
        {
            try
            {
                await _serverManagement.StopServerAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServer(Guid id)
        {
            try
            {
                await _serverManagement.DeleteServerAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
