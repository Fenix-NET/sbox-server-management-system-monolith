using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos
{
    public class ServerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public string Status { get; set; }
        public int CharacterCount { get; set; }
        public int ModCount { get; set; }

    }
}
