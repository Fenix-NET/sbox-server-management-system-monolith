using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Dtos.Request;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Domain.Aggregates;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/servers/{serverId}/players")]
    [ApiController]
    public class PlayersController : ControllerBase //Тут много чего надо делать-переделывать. Оптимизировать для реальной серверной функциональности.
    {
        private readonly IPlayerManagementService _playerManagementService;
        private readonly ILogger _logger;
        public PlayersController(ILogger logger, IPlayerManagementService playerManagementService)
        {
            _logger = logger;
            _playerManagementService = playerManagementService;
        }
        /// <summary>
        /// Получить список всех игроков сервера
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPlayers(Guid serverId)
        {
            try
            {
                var players = await _playerManagementService.GetPlayersByServerIdAsync(serverId);

                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Добавление игрока на сервер.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPlayer(Guid serverId, [FromBody] AddPlayerRequest request)
        {
            try
            {
                var playerId = await _playerManagementService.AddPlayerToServerAsync(serverId, request.Username, request.Role);

                return CreatedAtAction(nameof(AddPlayer), playerId);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Удаление игрока с сервера
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpDelete("{playerId}")]
        public async Task<IActionResult> RemovePlayer(Guid serverId, Guid playerId)
        {
            try
            {
                await _playerManagementService.RemovePlayerFromServerAsync(serverId, playerId);

                return Ok($"Player with id: {playerId} delete");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Забанить игрока по ID
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpPost("{playerId}/ban")]
        public async Task<IActionResult> BanPlayer(Guid playerId)
        {
            try
            {
                await _playerManagementService.BanPlayerAsync(playerId);

                return Ok($"Player with id: {playerId} Banned");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Разбанить игрока по ID
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpPost("{playerId}/unban")]
        public async Task<IActionResult> UnbanPlayer(Guid playerId)
        {
            try
            {
                await _playerManagementService.UnbanPlayerAsync(playerId);

                return Ok($"Player with id: {playerId} UnBanned");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
