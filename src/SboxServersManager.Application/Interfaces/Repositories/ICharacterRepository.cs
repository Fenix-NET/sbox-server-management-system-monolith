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
        Task<Character> GetByIdAsync(Guid id);
        Task<IEnumerable<Character>> GetByServerIdAsync(Guid serverId);
        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(Character character);

    }
}
