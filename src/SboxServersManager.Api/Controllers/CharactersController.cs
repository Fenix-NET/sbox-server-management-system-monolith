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
    public class CharactersController : ControllerBase //Тут много чего надо делать-переделывать. Оптимизировать для реальной серверной функциональности.
    {
        private readonly ICharacterManagementService _characterManagementService;
        private readonly ILogger _logger;
        public CharactersController(ILogger logger, ICharacterManagementService characterManagementService)
        {
            _logger = logger;
            _characterManagementService = characterManagementService;
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
                var players = await _characterManagementService.GetPlayersByServerIdAsync(serverId);

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
                var playerId = await _characterManagementService.AddPlayerToServerAsync(serverId, request.Username, request.Role);

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
                await _characterManagementService.RemovePlayerFromServerAsync(serverId, playerId);

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
                await _characterManagementService.BanPlayerAsync(playerId);

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
                await _characterManagementService.UnbanPlayerAsync(playerId);

                return Ok($"Player with id: {playerId} UnBanned");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
