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
        Task<Server> GetByIdAsync(Guid id, bool trackChange);
        Task<IEnumerable<Server>> GetAllAsync(bool trackChange);
        Task AddAsync(Server server);
        void UpdateServer(Server server);
    }
}
