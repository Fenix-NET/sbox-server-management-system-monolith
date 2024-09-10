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
        private readonly ICharacterRepository _characterRepository;
        private readonly IServerRepository _serverRepository;

        public CharacterManagementService(ICharacterRepository characterRepository, IServerRepository serverRepository)
        {
            _characterRepository = characterRepository;
            _serverRepository = serverRepository;
        }

        public async Task<IEnumerable<CharacterDto>> GetCharactersByServerIdAsync(Guid serverId)
        {
            var characters = await _characterRepository.GetByServerIdAsync(serverId);

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
            var server = await _serverRepository.GetByIdAsync(serverId);
            if (server == null) throw new ArgumentException("Server not found");

            Character character = new Character(name, role, serverId);

            server.AddCharacter(character);

            await _characterRepository.AddAsync(character);
            await _serverRepository.UpdateAsync(server);

            return character.Id;
        }
        public async Task RemoveCharacterFromServerAsync(Guid serverId, Guid characterId) //Тут кривая реализация, в реальном приложении логика будет другая
        {
            var server = await _serverRepository.GetByIdAsync(serverId);
            if (server == null) throw new ArgumentException("Server not found");

            var character = server.GetCharacter(characterId);
            if (character == null) throw new ArgumentException("Character not found");

            server.RemoveCharacter(character);
            await _characterRepository.DeleteAsync(character);
            await _serverRepository.UpdateAsync(server);
        }

        public async Task BanCharacterAsync(Guid characterId)//Добавить проверки
        {
            var character = await _characterRepository.GetByIdAsync(characterId);
            if (character == null) throw new ArgumentException("Character not found");

            character.IsBanned = true;
            character.DateReceivingBan = DateTime.UtcNow;

            await _characterRepository.UpdateAsync(character);
        }

        public async Task UnbanCharacterAsync(Guid characterId)//Добавить проверки
        {
            var character = await _characterRepository.GetByIdAsync(characterId);
            if (character == null) throw new ArgumentException("Character not found");

            character.IsBanned = false;
            character.DateReceivingBan = null;
            await _characterRepository.UpdateAsync(character);
        }
    }
}
