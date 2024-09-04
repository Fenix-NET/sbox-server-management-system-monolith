using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos
{
    public class CreateServerRequest
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }

    }
}
