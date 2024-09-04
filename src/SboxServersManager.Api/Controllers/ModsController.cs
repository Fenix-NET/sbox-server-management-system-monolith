using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/servers/{serverId}/mods")]
    [ApiController]
    public class ModsController : ControllerBase
    {
        public ModsController()
        {
            
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMods()
        {
            return Ok();
        }

        // Получение списка модов, установленных на сервере
        [HttpGet]
        public async Task<IActionResult> GetModsByServerId(Guid serverId)
        {
            return Ok();
        }

        // Установка мода на сервер
        [HttpPost("install")]
        public async Task<IActionResult> InstallMod()
        {
            return NoContent();
        }

        // Удаление мода с сервера
        [HttpDelete("{modId}")]
        public async Task<IActionResult> RemoveMod(Guid serverId, Guid modId)
        {
            return NoContent();
        }

    }
}
