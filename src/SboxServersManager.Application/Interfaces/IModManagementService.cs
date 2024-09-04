using SboxServersManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces
{
    public interface IModManagementService
    {
        Task<IEnumerable<ModDto>> GetAllModsAsync();
        Task<IEnumerable<ModDto>> GetModsByServerIdAsync(Guid serverId);
        Task InstallModOnServerAsync(Guid serverId, Guid modId);
        Task RemoveModFromServerAsync(Guid serverId, Guid modId);
    }
}
