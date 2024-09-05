using SboxServersManager.Domain.Entities;
using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Dtos
{
    public class AdminTaskDto
    {
        public Guid Id { get; set; }
        public Guid? ServerId { get; set; }
        public AdminTaskType Type { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public string? Details { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        public string? Owner { get; set; }
        public string? Annotation { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
