using SboxServersManager.Application.Dtos;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Domain.Entities;
using SboxServersManager.Domain.Enums;

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
            var characters = await _repositoryManager.character.GetAllByServerIdAsync(serverId, false);

            return characters.Select(player => new CharacterDto
            {
                Id = player.Id,
                Username = player.Name,
                IsBanned = player.IsBanned,
                LastActive = player.LastActive
            });
        }
        public async Task<Guid> AddCharacterToServerAsync(Guid serverId, string name, PlayerRole role)//Тут кривая реализация, в реальном приложении логика будет другая
        {
            var server = await _repositoryManager.server.GetByIdAsync(serverId, true);
            if (server == null) throw new ArgumentException("Server not found");

            Character character = new Character(name, serverId);

            server.AddCharacter(character);

            await _repositoryManager.character.AddAsync(character);
            _repositoryManager.server.UpdateServer(server);
            
            await _repositoryManager.SaveAsync();

            return character.Id;
        }
        public async Task RemoveCharacterFromServerAsync(Guid serverId, Guid characterId) //Тут кривая реализация, в реальном приложении логика будет другая
        {
            //var server = await _repositoryManager.server.GetByIdAsync(serverId, true);
            //if (server == null) throw new ArgumentException("Server not found");

            var character = await _repositoryManager.character.GetByServerIdAsync(serverId: serverId, characterId: characterId, true);
            if (character == null) throw new ArgumentException("Character not found");

            character.SoftDelete();

            await _repositoryManager.SaveAsync();
        }

        public async Task BanCharacterAsync(Guid characterId)//Добавить проверки
        {
            var character = await _repositoryManager.character.GetByIdAsync(characterId, true);
            if (character == null) throw new ArgumentException("Character not found");

            character.IsBanned = true;
            character.BanStartDate = DateTime.UtcNow;

            await _repositoryManager.SaveAsync();
        }

        public async Task UnbanCharacterAsync(Guid characterId)//Добавить проверки
        {
            var character = await _repositoryManager.character.GetByIdAsync(characterId, true);
            if (character == null) throw new ArgumentException("Character not found");

            character.IsBanned = false;
            character.BanStartDate = null;
            character.BanEndDate = null;

            await _repositoryManager.SaveAsync();
        }
    }
}
