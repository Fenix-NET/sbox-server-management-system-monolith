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
        public Guid Id { get; private set; }
        public Guid? ServerId { get; private set; }
        public AdminTaskType Type { get; private set; }
        public Priority Priority { get; private set; }
        public string? Details { get; private set; }
        public Status Status { get; private set; }
        public DateTime? ScheduledTime { get; private set; }
        public DateTime? CompletedTime { get; private set; }
        public Guid? Owner { get; private set; }
        public string? Annotation { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public AdminTask(AdminTaskType type, Priority priority, string? details ="", Guid? serverId = null, DateTime? scheduledTime = null, Guid? owner = null)
        {
            Id = Guid.NewGuid();
            ServerId = serverId;
            Type = type;
            Priority = priority;
            Details = details;
            ScheduledTime = scheduledTime;
            CreatedDate = DateTime.UtcNow;
            Owner = owner;
            Status = Status.New;
        }

        public void MarkAsCompleted()
        {
            if (Status == Status.Completed)
                throw new InvalidOperationException("Task is already completed.");

            Status = Status.Completed;
            CompletedTime = DateTime.UtcNow;
        }
        public void MarkAsFailed()
        {
            if (Status == Status.Failed)
                throw new InvalidOperationException("Task has already failed.");

            Status = Status.Failed;
        }
        public void AcceptTask(Guid owner)
        {
            if(Owner != null && Status == Status.Completed)
                throw new InvalidOperationException("Task has already completed.");

        }

    }
}
