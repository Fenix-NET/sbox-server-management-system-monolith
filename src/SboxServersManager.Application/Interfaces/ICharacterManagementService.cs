using SboxServersManager.Application.Dtos;
using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces
{
    public interface ICharacterManagementService
    {
        Task<IEnumerable<CharacterDto>> GetCharactersByServerIdAsync(Guid serverId);
        Task<Guid> AddCharacterToServerAsync(Guid serverId, string username, PlayerRole role);
        Task RemoveCharacterFromServerAsync(Guid serverId, Guid playerId);
        Task BanCharacterAsync(Guid playerId);
        Task UnbanCharacterAsync(Guid playerId);
    }
}
