using SboxServersManager.Application.Dtos;
using SboxServersManager.Application.Interfaces;
using SboxServersManager.Application.Interfaces.Repositories;
using SboxServersManager.Domain.Entities;
using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Services
{
    public class PlayerManagementService : IPlayerManagementService //Тут много чего надо оптимизировать.
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IServerRepository _serverRepository;

        public PlayerManagementService(IPlayerRepository playerRepository, IServerRepository serverRepository)
        {
            _playerRepository = playerRepository;
            _serverRepository = serverRepository;
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayersByServerIdAsync(Guid serverId)
        {
            var players = await _playerRepository.GetByServerIdAsync(serverId);

            return players.Select(player => new PlayerDto
            {
                Id = player.Id,
                Username = player.Username,
                Role = player.Role.ToString(),
                IsBanned = player.IsBanned,
                LastActive = player.LastActive
            });
        }
        public async Task<Guid> AddPlayerToServerAsync(Guid serverId, string username, PlayerRole role)//Тут кривая реализация, в реальном приложении логика будет другая
        {
            var server = await _serverRepository.GetByIdAsync(serverId);
            if (server == null) throw new ArgumentException("Server not found");

            Player player = new Player(username, role, serverId);

            server.AddPlayer(player);

            await _playerRepository.AddAsync(player);
            await _serverRepository.UpdateAsync(server);

            return player.Id;
        }
        public async Task RemovePlayerFromServerAsync(Guid serverId, Guid playerId) //Тут кривая реализация, в реальном приложении логика будет другая
        {
            var server = await _serverRepository.GetByIdAsync(serverId);
            if (server == null) throw new ArgumentException("Server not found");

            var player = server.GetPlayer(playerId);
            if (player == null) throw new ArgumentException("Player not found");

            server.RemovePlayer(player);
            await _playerRepository.DeleteAsync(player);
            await _serverRepository.UpdateAsync(server);
        }

        public async Task BanPlayerAsync(Guid playerId)//Добавить проверки
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            if (player == null) throw new ArgumentException("Player not found");

            player.IsBanned = true;
            player.DateReceivingBan = DateTime.UtcNow;

            await _playerRepository.UpdateAsync(player);
        }

        public async Task UnbanPlayerAsync(Guid playerId)//Добавить проверки
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            if (player == null) throw new ArgumentException("Player not found");

            player.IsBanned = false;
            player.DateReceivingBan = null;
            await _playerRepository.UpdateAsync(player);
        }
    }
}
