using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Dtos.Request;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Domain.Aggregates;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/servers/{serverId}/mods")]
    [ApiController]
    public class ModsController : ControllerBase // Та же самаю оптимизация роутинга, валидация...
    {
        private readonly IModManagementService _modManagementService;
        private readonly ILogger _logger;
        public ModsController(IModManagementService modManagementService, ILogger logger)
        {
            _logger = logger;
            _modManagementService = modManagementService;
        }
        /// <summary>
        /// Получить список всех доступных модификаций.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllMods()
        {
            try
            {
                var mods = await _modManagementService.GetAllModsAsync();
                return Ok(mods);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получение списка модов, установленных на сервере.
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetModsByServerId(Guid serverId)
        {
            try
            {
                var mods = await _modManagementService.GetModsByServerIdAsync(serverId);
                return Ok(mods);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Установка мода на сервер.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("install")]
        public async Task<IActionResult> InstallMod(Guid serverId, [FromBody] InstallModRequest request)
        {
            try
            {
                await _modManagementService.InstallModOnServerAsync(serverId, request.ModId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Удаление мода с сервера.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="modId"></param>
        /// <returns></returns>
        [HttpDelete("{modId}")]
        public async Task<IActionResult> RemoveMod(Guid serverId, Guid modId)
        {
            try
            {
                await _modManagementService.RemoveModFromServerAsync(serverId, modId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
