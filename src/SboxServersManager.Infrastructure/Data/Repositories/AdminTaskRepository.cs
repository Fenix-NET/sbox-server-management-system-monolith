using Microsoft.EntityFrameworkCore;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Entities;
using SboxServersManager.Domain.Enums;

namespace SboxServersManager.Infrastructure.Data.Repositories
{
    public class AdminTaskRepository : IAdminTaskRepository
    {
        private readonly ServersManagerDbContext _context;

        public AdminTaskRepository(ServersManagerDbContext context)
        {
            _context = context;
        }

        public async Task<AdminTask> GetByIdAsync(Guid id)
        {
            return await _context.AdminTasks.SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task<IEnumerable<AdminTask>> GetPendingTasksAsync()
        {
            return await _context.AdminTasks.Where(t => t.Status == Status.Pending).ToListAsync();
        }
        public async Task<IEnumerable<AdminTask>> GetTasksByServerIdAsync(Guid serverId)
        {
            return await _context.AdminTasks.Where(t => t.ServerId == serverId).ToListAsync();
        }
        public async Task AddAsync(AdminTask task)
        {
            await _context.AdminTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(AdminTask task)
        {
            _context.AdminTasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
