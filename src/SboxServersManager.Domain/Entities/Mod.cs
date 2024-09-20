using SboxServersManager.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Mod : BaseEntity
    {
        public string Name { get; set; }
        public string? Version { get; set; }
        public string? Description { get; set; }
        public List<Server>? InstalledOnServers { get; set; }
    }
}
