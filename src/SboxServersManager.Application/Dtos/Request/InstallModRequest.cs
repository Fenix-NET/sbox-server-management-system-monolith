using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos.Request
{
    public class InstallModRequest
    {
        public Guid ModId { get; set; }
        public string Name { get; set; }
    }
}
