using SboxServersManager.Application.Dtos;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Services
{
    public class ModManagementService : IModManagementService //Аналогично всю логику подстраивать под сервер.
    {
        private readonly IModRepository _modRepository;
        private readonly IServerRepository _serverRepository;

        public ModManagementService(IModRepository modRepository, IServerRepository serverRepository)
        {
            _modRepository = modRepository;
            _serverRepository = serverRepository;
        }
        public async Task<IEnumerable<ModDto>> GetAllModsAsync()
        {
            var mods = await _modRepository.GetAllAsync();
            return mods.Select(mod => new ModDto
            {
                Id = mod.Id,
                Name = mod.Name,
                Version = mod.Version,
                Description = mod.Description
            });
        }
        public async Task<IEnumerable<ModDto>> GetModsByServerIdAsync(Guid serverId)
        {
            var server = await _serverRepository.GetByIdAsync(serverId);
            if (server == null) throw new Exception("Server not found");

            return server.ActiveMods.Select(mod => new ModDto
            {
                Id = mod.Id,
                Name = mod.Name,
                Version = mod.Version,
                Description = mod.Description
            });
        }
        public async Task InstallModOnServerAsync(Guid serverId, Guid modId)
        {
            var server = await _serverRepository.GetByIdAsync(serverId);
            if (server == null) throw new Exception("Server not found");

            var mod = await _modRepository.GetByIdAsync(modId);
            if (mod == null) throw new Exception("Mod not found");

            server.AddMod(mod);
            await _serverRepository.UpdateAsync(server);
        }
        public async Task RemoveModFromServerAsync(Guid serverId, Guid modId)
        {
            var server = await _serverRepository.GetByIdAsync(serverId);
            if (server == null) throw new Exception("Server not found");

            var mod = server.ActiveMods.FirstOrDefault(m => m.Id == modId);
            if (mod == null) throw new Exception("Mod not found on this server");

            server.RemoveMod(mod);
            await _serverRepository.UpdateAsync(server);
        }
    }
}
