using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos.Request
{
    public class AddPlayerRequest
    {
        public string Username { get; set; }
        public PlayerRole Role { get; set; }

    }
}
