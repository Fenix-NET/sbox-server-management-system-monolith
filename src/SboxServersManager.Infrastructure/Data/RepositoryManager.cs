using Newtonsoft.Json.Bson;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Data
{
    public class RepositoryManager : IRepositoryManager, IDisposable
    {
        private readonly ServersManagerDbContext _context;
        private readonly Lazy<IAdminTaskRepository> _adminTaskRepository;
        private readonly Lazy<ICharacterRepository> _characterRepository;
        private readonly Lazy<IModRepository> _modRepository;
        private readonly Lazy<IServerRepository> _serverRepository;

        private bool disposed;

        public RepositoryManager(ServersManagerDbContext context)
        {
            _context = context;

            _adminTaskRepository = new Lazy<IAdminTaskRepository>(() => new AdminTaskRepository(context));
            _characterRepository = new Lazy<ICharacterRepository>(() => new CharacterRepository(context));
            _modRepository = new Lazy<IModRepository>(() => new ModRepository(context));
            _serverRepository = new Lazy<IServerRepository>(() => new ServerRepository(context));
        }

        public IAdminTaskRepository adminTask => _adminTaskRepository.Value;
        public ICharacterRepository character => _characterRepository.Value;
        public IModRepository mod => _modRepository.Value;
        public IServerRepository server => _serverRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null) _context.Dispose();
            }
        }
    }
}
