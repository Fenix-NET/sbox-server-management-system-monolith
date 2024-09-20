using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Aggregates;
using SboxServersManager.Domain.Entities;

namespace SboxServersManager.Infrastructure.Data.Repositories
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ServersManagerDbContext context)
            :base(context) 
        {
        }
        public async Task<Character> GetByIdAsync(Guid id, bool trackChange)
        {
            return await FindByCondition(c => c.Id.Equals(id), trackChange).SingleOrDefaultAsync();
        }
        public async Task<Character> GetByServerIdAsync(Guid serverId, Guid characterId, bool trackChange)
        {
            return await FindByCondition(c => c.Id.Equals(characterId) && c.ServerId.Equals(serverId), trackChange).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Character>> GetAllByServerIdAsync(Guid serverId, bool trackChange)
        {
            return await FindByCondition(c => c.ServerId.Equals(serverId), trackChange).ToListAsync();
        }

        public async Task AddAsync(Character character)
        {
            await AddAsync(character);
        }
    }
}
