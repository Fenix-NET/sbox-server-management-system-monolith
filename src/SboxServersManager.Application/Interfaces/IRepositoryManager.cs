using SboxServersManager.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces
{
    public interface IRepositoryManager
    {
        IAdminTaskRepository adminTask { get; }
        ICharacterRepository character { get; }
        IModRepository mod { get; }
        IServerRepository server { get; }

        Task SaveAsync();
    }
}
