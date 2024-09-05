using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SboxServersManager.Domain.Entities;
using SboxServersManager.Domain.Enums;

namespace SboxServersManager.Domain.Aggregates
{
    public class Server
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Port { get; private set; }
        public ServerStatus Status { get; private set; }
        public List<Player>? Players { get; private set; }
        public List<Mod> ActiveMods { get; private set; }

        public Server(string name, string address, int port)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Port = port;
            Status = ServerStatus.Offline;
            Players = new List<Player>();
            ActiveMods = new List<Mod>();
        }
        public void Start()
        {
            if (Status == ServerStatus.Online)
                throw new InvalidOperationException("Server is already online.");

            Status = ServerStatus.Online;
        }
        public void Stop()
        {
            if (Status == ServerStatus.Offline)
                throw new InvalidOperationException("Server is already offline.");

            Status = ServerStatus.Offline;
        }
        public void AddPlayer(Player player)
        {
            if (Players.Any(p => p.Id == player.Id))
                throw new InvalidOperationException("Player is already connected to the server.");

            Players.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
        public Player GetPlayer(Guid playerId)
        {
            return Players.FirstOrDefault(p => p.Id == playerId);
        }
        public void AddMod(Mod mod)
        {
            if (!ActiveMods.Contains(mod))
            {
                ActiveMods.Add(mod);
            }
        }
        public void RemoveMod(Mod mod)
        {
            ActiveMods.Remove(mod);
        }

    }
}
