using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SboxServersManager.Application.Dtos.Request;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Domain.Aggregates;
using SboxServersManager.Domain.Entities;

namespace SboxServersManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiversion}/servers/{serverId}/characters")]
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
        /// Получить список всех персонажей сервера
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCharacters(Guid serverId)
        {
            try
            {
                var characters = await _characterManagementService.GetCharactersByServerIdAsync(serverId);

                return Ok(characters);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Добавление персонажа на сервер.
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCharacter(Guid serverId, [FromBody] AddCharacterRequest request)
        {
            try
            {
                var playerId = await _characterManagementService.AddCharacterToServerAsync(serverId, request.Name, request.Role);

                return CreatedAtAction(nameof(AddCharacter), playerId);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Удаление персонажа с сервера
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpDelete("{playerId}")]
        public async Task<IActionResult> RemoveCharacter(Guid serverId, Guid characterId)
        {
            try
            {
                await _characterManagementService.RemoveCharacterFromServerAsync(serverId, characterId);

                return Ok($"Character with id: {characterId} delete");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Забанить Персонажа по ID
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpPost("{playerId}/ban")]
        public async Task<IActionResult> BanCharacter(Guid characterId)
        {
            try
            {
                await _characterManagementService.BanCharacterAsync(characterId);

                return Ok($"Character with id: {characterId} Banned");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Разбанить Персонажа по ID
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpPost("{playerId}/unban")]
        public async Task<IActionResult> UnbanCharacter(Guid characterId)
        {
            try
            {
                await _characterManagementService.UnbanCharacterAsync(characterId);

                return Ok($"Character with id: {characterId} UnBanned");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
