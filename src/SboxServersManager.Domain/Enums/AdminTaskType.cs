using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Enums
{
    public enum AdminTaskType
    {
        None = 4200,
        RebootServer = 4201,
        StartServer = 4202,
        StopServer = 4203,
        StartGameEvent = 4204,
        PunishPlayer = 4205,
        ConsiderComplaints = 4206,
        AddMod = 4207,
        UpdateMod = 4208,
        Custom = 4209,
    }
}
