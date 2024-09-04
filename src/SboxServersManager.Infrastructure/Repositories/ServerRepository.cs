using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly ServersManagerDbContext _context;

        public ServerRepository(ServersManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Server> GetByIdAsync(Guid id) //.AsSplitQuery()?
        {
            var server = await _context.Servers.AsNoTracking()
                .Include(s => s.Players)
                .Include(s => s.ActiveMods)
                .FirstOrDefaultAsync(s => s.Id == id);
            
            return server;
        }

        public async Task<IEnumerable<Server>> GetAllAsync() //.AsSplitQuery()?
        {
            var servers = await _context.Servers.AsNoTracking()
                .Include(s => s.Players)
                .Include(s => s.ActiveMods)
                .ToListAsync();
            
            return servers;
        }

        public async Task AddAsync(Server server)
        {
            await _context.Servers.AddAsync(server);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Server server)
        {
            _context.Servers.Update(server);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Server server)
        {
            _context.Servers.Remove(server);
            await _context.SaveChangesAsync();
        }

    }
}
