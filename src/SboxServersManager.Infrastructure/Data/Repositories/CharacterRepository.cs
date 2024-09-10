using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Entities;

namespace SboxServersManager.Infrastructure.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ServersManagerDbContext _context;

        public CharacterRepository(ServersManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Character> GetByIdAsync(Guid id)
        {
            var player = await _context.Characters.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return player;
        }

        public async Task<IEnumerable<Character>> GetByServerIdAsync(Guid serverId)
        {
            return await _context.Characters.AsNoTracking().Where(p => p.ServerId == serverId).ToListAsync();
        }

        public async Task AddAsync(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Character character)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

    }
}
