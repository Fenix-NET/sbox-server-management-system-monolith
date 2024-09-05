using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos.Request
{
    public class CreateAdminTaskRequest
    {
        public Guid? ServerId { get; set; }
        public AdminTaskType Type { get; set; }
        public Priority? Priority { get; set; }
        public string? Details { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string? Owner { get; set; }
    }
}
