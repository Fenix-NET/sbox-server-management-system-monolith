using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos.Request
{
    public class AddCharacterRequest
    {
        public string Name { get; set; }
        public PlayerRole Role { get; set; }

    }
}
