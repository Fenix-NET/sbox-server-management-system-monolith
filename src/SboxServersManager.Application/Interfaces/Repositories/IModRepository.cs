using SboxServersManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Repositories
{
    public interface IModRepository
    {
        Task<Mod> GetByIdAsync(Guid id);
        Task<IEnumerable<Mod>> GetAllAsync();
        Task AddAsync(Mod mod);
        Task UpdateAsync(Mod mod);
        Task DeleteAsync(Mod mod);

    }
}
