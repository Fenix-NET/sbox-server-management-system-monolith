using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Aggregates;

namespace SboxServersManager.Infrastructure.Data.Repositories
{
    public class ServerRepository : BaseRepository<Server>, IServerRepository
    {
        public ServerRepository(ServersManagerDbContext context)
            : base(context) 
        {
        }

        public async Task<Server> GetByIdAsync(Guid id, bool trackChange) //.AsSplitQuery()?
        {
            var server = await FindByCondition(s => s.Id.Equals(id), trackChange)
                .Include(s => s.Characters)
                .Include(s => s.ActiveMods)
                .SingleOrDefaultAsync();

            return server;
        }

        public async Task<IEnumerable<Server>> GetAllAsync(bool trackChange) //.AsSplitQuery()?
        {
            var servers = await FindAll(trackChange)
                .Include(s => s.Characters)
                .Include(s => s.ActiveMods)
                .ToListAsync();

            return servers;
        }

        public async Task AddAsync(Server server)
        {
            await Create(server);
        }
        public void UpdateServer(Server server)
        {
            Update(server);
        }
        public void HardDeleteServer(Server server)
        {
            Delete(server);
        }
    }
}
