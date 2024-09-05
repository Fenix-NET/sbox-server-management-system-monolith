using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Entities;

namespace SboxServersManager.Infrastructure.Data.Repositories
{
    public class ModRepository : IModRepository //Оптимизировать все обращения, проверки...
    {
        private readonly ServersManagerDbContext _context;

        public ModRepository(ServersManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Mod> GetByIdAsync(Guid id)
        {
            return await _context.Mods.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Mod>> GetAllAsync()
        {
            return await _context.Mods.AsNoTracking().ToListAsync();
        }
        public async Task AddAsync(Mod mod)
        {
            await _context.Mods.AddAsync(mod);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Mod mod)
        {
            _context.Mods.Update(mod);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Mod mod)
        {
            _context.Mods.Remove(mod);
            await _context.SaveChangesAsync();
        }

    }
}
