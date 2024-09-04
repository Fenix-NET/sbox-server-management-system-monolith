using SboxServersManager.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Repositories
{
    public interface IServerRepository
    {
        Task<Server> GetByIdAsync(Guid id);
        Task<IEnumerable<Server>> GetAllAsync();
        Task AddAsync(Server server);
        Task UpdateAsync(Server server);
        Task DeleteAsync(Server server);

    }
}
