using SboxServersManager.Application.Dtos;
using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces
{
    public interface IPlayerManagementService
    {
        Task<IEnumerable<PlayerDto>> GetPlayersByServerIdAsync(Guid serverId);
        Task<Guid> AddPlayerToServerAsync(Guid serverId, string username, PlayerRole role);
        Task RemovePlayerFromServerAsync(Guid serverId, Guid playerId);
        Task BanPlayerAsync(Guid playerId);
        Task UnbanPlayerAsync(Guid playerId);
    }
}
