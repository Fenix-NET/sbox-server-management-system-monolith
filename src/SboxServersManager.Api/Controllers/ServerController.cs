using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Dtos.Request;
using SboxServersManager.Application.Interfaces;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/{v:apiversion}/server")]
    public class ServerController : ControllerBase
    {
        private readonly ILogger<ServerController> _logger;
        private readonly IServerManagementService _serverManagement;

        public ServerController(ILogger<ServerController> logger, IServerManagementService serverManagement)
        {
            _logger = logger;
            _serverManagement = serverManagement;
        }
        /// <summary>
        /// Создать новый сервер.
        /// </summary>
        /// <param name="serverRequest"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateServer([FromBody]CreateServerRequest serverRequest)
        {
            _logger.LogInformation($"[POST]CreateServer Starting. Name:{serverRequest.Name}, IP:{serverRequest.IPAddress}, Port:{serverRequest.Port}");

            if (serverRequest == null) return BadRequest();

            try
            {
                var newServerId = await _serverManagement.CreateServerAsync(serverRequest);

                return CreatedAtAction(nameof(GetServerById), value: new { id = newServerId });
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"CreateServer Error. Error message: {ex.Message}");
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Получить информацию о сервере по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                _logger.LogWarning($"GetServerById Error. Id:{id}. Error message: {ex.Message}");
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Получить список всех серверов.
        /// </summary>
        /// <returns></returns>
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
                _logger.LogWarning($"GetAllServers Error. Error message: {ex.Message}");
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Включить сервер.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                _logger.LogWarning($"StartServer Error. Id:{id}. Error message: {ex.Message}");
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Выключить сервер.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                _logger.LogWarning($"StopServer Error. Id:{id}. Error message: {ex.Message}");
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Удалить сервер.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                _logger.LogWarning($"DeleteServer Error. Id:{id}. Error message: {ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayersOnServer(Guid id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }
    }
}
