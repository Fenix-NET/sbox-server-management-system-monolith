using SboxServersManager.Application.Dtos;
using SboxServersManager.Application.Dtos.Request;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Services
{
    public class ServerManagementService : IServerManagementService
    {
        private readonly IServerRepository _repository;
        public ServerManagementService(IServerRepository repository)
        {
            _repository = repository;
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

            await _repository.AddAsync(server);

            return server.Id;
        }
        public async Task<ServerDto> GetServerAsync(Guid id)
        {
            var server = await _repository.GetByIdAsync(id);

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
            var servers = await _repository.GetAllAsync();

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
            var server = await _repository.GetByIdAsync(id);
            if(server == null) throw new Exception($"Server with ID:{id} Not Found");

            await _repository.DeleteAsync(server);
        }

        public async Task StartServerAsync(Guid id) //Реализовать проверки
        {
            var server = await _repository.GetByIdAsync(id);
            if (server == null) throw new Exception($"Server with ID:{id} Not Found");

            server.Start();
            
            await _repository.UpdateAsync(server);
        }

        public async Task StopServerAsync(Guid id)//Реализовать проверки
        {
            var server = await _repository.GetByIdAsync(id);
            if (server == null) throw new Exception($"Server with ID:{id} Not Found");

            server.Stop();

            await _repository.UpdateAsync(server);
        }
    }
}
