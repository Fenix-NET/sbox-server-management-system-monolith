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
        public Guid Id { get; set; } //В дальнейшем можно использовать SteamID
        public string Username { get; set; }
        public PlayerRole Role { get; set; }
        public bool IsBanned { get; set; }
        public int Warn { get; set; }
        public DateTime LastActive { get; set; }
        public Guid ServerId { get; set; }

    }
}
