using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Name { get; set; }
        public PlayerRole Role { get; set; } = PlayerRole.None;
        public bool IsVip { get; set; }
        public bool IsBanned { get; set; } = false;
        public DateTime? BanStartDate { get; set; }
        public DateTime? BanEndDate { get; set; }
        [Range(0, 5)]
        public int Warn { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastActive { get; set; }
        public Guid ServerId { get; set; }
        public Guid? UserId { get; set; }
        [Range(-100, 100)]
        public int Rating { get; set; }
        public int Level { get; set; }

        public Character(string name, PlayerRole role, Guid serverId)
        {
            Name = name;
            Role = role;
            ServerId = serverId;
        }

        public Character()
        {
            
        }

    }
}
