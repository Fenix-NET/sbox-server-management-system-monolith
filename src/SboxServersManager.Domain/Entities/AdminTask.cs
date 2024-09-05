using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class AdminTask
    {
        public Guid Id { get; set; }
        public Guid? ServerId { get; set; }
        public AdminTaskType Type { get; set; }
        public Priority Priority { get; set; } = Priority.Normal;
        public string? Details { get; set; }
        public Status Status { get; set; } = Status.New;
        public DateTime? ScheduledTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        public string? Owner { get; set; } //Заменить
        public string? Annotation { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
