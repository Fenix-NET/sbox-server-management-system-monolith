using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ServersManagerDbContext _context;

        public PlayerRepository(ServersManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Player> GetByIdAsync(Guid id)
        {
            var player = await _context.Players.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return player;
        }

        public async Task<IEnumerable<Player>> GetByServerIdAsync(Guid serverId)
        {
            return await _context.Players.AsNoTracking().Where(p => p.ServerId == serverId).ToListAsync();
        }

        public async Task AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }

    }
}
