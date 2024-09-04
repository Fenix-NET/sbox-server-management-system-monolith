using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsBanned { get; set; }
        public int Warn {  get; set; }  
        public DateTime? LastActive { get; set; }

    }
}
