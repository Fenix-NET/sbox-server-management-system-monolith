using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player> GetByIdAsync(Guid id);
        Task<IEnumerable<Player>> GetByServerIdAsync(Guid serverId);
        Task AddAsync(Player player);
        Task UpdateAsync(Player player);
        Task DeleteAsync(Player player);

    }
}
