using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Repositories
{
    public interface IAdminTaskRepository
    {
        Task<AdminTask> GetByIdAsync(Guid id);
        Task<IEnumerable<AdminTask>> GetPendingTasksAsync();
        Task<IEnumerable<AdminTask>> GetTasksByServerIdAsync(Guid serverId);
        Task AddAsync(AdminTask task);
        Task UpdateAsync(AdminTask task);
    }
}
