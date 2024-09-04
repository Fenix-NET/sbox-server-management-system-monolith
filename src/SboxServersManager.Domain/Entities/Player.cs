using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid(); //В дальнейшем можно использовать SteamID
        public string Username { get; set; }
        public PlayerRole Role { get; set; }
        public bool IsBanned { get; set; } = false;
        public DateTime? DateReceivingBan { get; set; }
        public int Warn { get; set; } = 0;
        public DateTime? LastActive { get; set; }
        public Guid ServerId { get; set; }

        public Player(string name, PlayerRole role, Guid serverId)
        {
            Username = name;
            Role = role;
            ServerId = serverId;
        }

    }
}
