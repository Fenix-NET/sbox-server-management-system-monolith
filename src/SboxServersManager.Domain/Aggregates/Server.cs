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
    public class Server : BaseEntity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Port { get; private set; }
        public ServerStatus Status { get; private set; }
        public List<Character>? Characters { get; private set; }
        public List<Mod> ActiveMods { get; private set; }

        public Server(string name, string address, int port)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Port = port;
            Status = ServerStatus.Offline;
            Characters = new List<Character>();
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
        public void AddCharacter(Character character)
        {
            if (Characters.Any(p => p.Id == character.Id))
                throw new InvalidOperationException("Player is already connected to the server.");

            Characters.Add(character);
        }
        public void RemoveCharacter(Character character)
        {
            Characters.Remove(character);
        }
        public Character GetCharacter(Guid characterId)
        {
            return Characters.FirstOrDefault(p => p.Id == characterId);
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
