using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character> GetByIdAsync(Guid id, bool trackChange);
        Task<IEnumerable<Character>> GetAllByServerIdAsync(Guid serverId, bool trackChange);
        Task<Character> GetByServerIdAsync(Guid serverId, Guid characterId, bool trackChange);
        Task AddAsync(Character character);
    }
}
