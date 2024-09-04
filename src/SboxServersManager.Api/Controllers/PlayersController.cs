using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/servers/{serverId}/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        public PlayersController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers(Guid serverId)
        {
            return Ok(players);
        }

        // Добавление игрока на сервер
        [HttpPost]
        public async Task<IActionResult> AddPlayer()
        {
            return CreatedAtAction(nameof(GetPlayers), new { serverId = serverId }, null);
        }

        // Удаление игрока с сервера
        [HttpDelete("{playerId}")]
        public async Task<IActionResult> RemovePlayer()
        {
            return NoContent();
        }
        // Блокировка игрока
        [HttpPost("{playerId}/ban")]
        public async Task<IActionResult> BanPlayer(Guid playerId)
        {
            return NoContent();
        }

        // Разблокировка игрока
        [HttpPost("{playerId}/unban")]
        public async Task<IActionResult> UnbanPlayer(Guid playerId)
        {
            return NoContent();
        }

    }
}
