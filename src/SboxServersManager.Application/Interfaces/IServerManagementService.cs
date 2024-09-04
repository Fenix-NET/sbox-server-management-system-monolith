using SboxServersManager.Application.Dtos;
using SboxServersManager.Application.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces
{
    public interface IServerManagementService
    {
        Task<Guid> CreateServerAsync(CreateServerRequest serverRequest);
        Task<ServerDto> GetServerAsync(Guid id);
        Task<IEnumerable<ServerDto>> GetAllServersAsync();
        Task StartServerAsync(Guid id);
        Task StopServerAsync(Guid id);
        Task DeleteServerAsync(Guid id);
    }
}
