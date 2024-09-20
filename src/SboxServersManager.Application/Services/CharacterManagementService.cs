using SboxServersManager.Application.Dtos;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Entities;
using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Services
{
    public class CharacterManagementService : ICharacterManagementService //Тут много чего надо оптимизировать.
    {
        private readonly IRepositoryManager _repositoryManager;

        public CharacterManagementService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<CharacterDto>> GetCharactersByServerIdAsync(Guid serverId)
        {
            var characters = await _repositoryManager.character.GetByServerIdAsync(serverId);

            return characters.Select(player => new CharacterDto
            {
                Id = player.Id,
                Username = player.Name,
                Role = player.Role.ToString(),
                IsBanned = player.IsBanned,
                LastActive = player.LastActive
            });
        }
        public async Task<Guid> AddCharacterToServerAsync(Guid serverId, string name, PlayerRole role)//Тут кривая реализация, в реальном приложении логика будет другая
        {
            var server = await _repositoryManager.server.GetByIdAsync(serverId);
            if (server == null) throw new ArgumentException("Server not found");

            Character character = new Character(name, role, serverId);

            server.AddCharacter(character);

            await _repositoryManager.character.AddAsync(character);
            await _repositoryManager.server.UpdateAsync(server);

            return character.Id;
        }
        public async Task RemoveCharacterFromServerAsync(Guid serverId, Guid characterId) //Тут кривая реализация, в реальном приложении логика будет другая
        {
            var server = await _repositoryManager.server.GetByIdAsync(serverId);
            if (server == null) throw new ArgumentException("Server not found");

            var character = server.GetCharacter(characterId);
            if (character == null) throw new ArgumentException("Character not found");

            server.RemoveCharacter(character);
            await _repositoryManager.character.DeleteAsync(character);
            await _repositoryManager.server.UpdateAsync(server);
        }

        public async Task BanCharacterAsync(Guid characterId)//Добавить проверки
        {
            var character = await _repositoryManager.character.GetByIdAsync(characterId);
            if (character == null) throw new ArgumentException("Character not found");

            character.IsBanned = true;
            character.BanStartDate = DateTime.UtcNow;

            await _repositoryManager.character.UpdateAsync(character);
        }

        public async Task UnbanCharacterAsync(Guid characterId)//Добавить проверки
        {
            var character = await _repositoryManager.character.GetByIdAsync(characterId);
            if (character == null) throw new ArgumentException("Character not found");

            character.IsBanned = false;
            character.BanStartDate = null;
            character.BanEndDate = null;
            await _repositoryManager.character.UpdateAsync(character);
        }
    }
}
