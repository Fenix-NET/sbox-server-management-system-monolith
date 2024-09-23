using SboxServersManager.Application.Dtos;
using SboxServersManager.Application.Dtos.Request;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Domain.Aggregates;
using System.Net;

namespace SboxServersManager.Application.Services
{
    public class ServerManagementService : IServerManagementService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ServerManagementService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Guid> CreateServerAsync(CreateServerRequest serverRequest)
        {
            if(string.IsNullOrEmpty(serverRequest.Name) || 
                string.IsNullOrEmpty(serverRequest.IPAddress) || 
                !IPAddress.TryParse(serverRequest.IPAddress, out IPAddress ip))
            {
                throw new ArgumentException(nameof(serverRequest) + $": Name:{serverRequest.Name}. IpAdress:{serverRequest.IPAddress}.");
            }
            
            //byte[] ipAdress = Encoding.UTF8.GetBytes(ip); //Добавить проверку. Или создать вспомогательный метод расширение.

            var server = new Server(serverRequest.Name, serverRequest.IPAddress, serverRequest.Port);

            await _repositoryManager.server.AddAsync(server);
            await _repositoryManager.SaveAsync();

            return server.Id;
        }
        public async Task<ServerDto> GetServerAsync(Guid id)
        {
            var server = await _repositoryManager.server.GetByIdAsync(id, false);

            if(server == null) return null;

            return new ServerDto
            {
                Id = server.Id,
                Name = server.Name,
                IPAddress = server.Address.ToString(),
                Port = server.Port,
                Status = server.Status.ToString(),
                CharacterCount = server.Characters.Count,
                ModCount = server.ActiveMods.Count
            };
        }

        public async Task<IEnumerable<ServerDto>> GetAllServersAsync()
        {
            var servers = await _repositoryManager.server.GetAllAsync(false);

            return servers.Select(server => new ServerDto
            {
                Id = server.Id,
                Name = server.Name,
                IPAddress = server.Address.ToString(),
                Port = server.Port,
                Status = server.Status.ToString(),
                CharacterCount = server.Characters.Count,
                ModCount = server.ActiveMods.Count
            });
        }

        public async Task DeleteServerAsync(Guid id)//Реализовать проверки
        {
            var server = await _repositoryManager.server.GetByIdAsync(id, true);
            if(server == null) throw new Exception($"Server with ID:{id} Not Found");

            server.SoftDelete();
            await _repositoryManager.SaveAsync();
        }

        public async Task StartServerAsync(Guid id) //Реализовать проверки
        {
            var server = await _repositoryManager.server.GetByIdAsync(id, true);
            if (server == null) throw new Exception($"Server with ID:{id} Not Found");

            server.Start();
            
            _repositoryManager.server.UpdateServer(server);
            await _repositoryManager.SaveAsync();
        }

        public async Task StopServerAsync(Guid id)//Реализовать проверки
        {
            var server = await _repositoryManager.server.GetByIdAsync(id, true);
            if (server == null) throw new Exception($"Server with ID:{id} Not Found");

            server.Stop();

            _repositoryManager.server.UpdateServer(server);
            await _repositoryManager.SaveAsync();
        }
    }
}
