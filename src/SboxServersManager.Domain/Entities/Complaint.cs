using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SboxServersManager.Domain.Enums;

namespace SboxServersManager.Domain.Entities
{
    public class Complaint
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Guid PlayerId { get; private set; }
        public Priority? Priority { get; private set; }
        public Status Status { get; private set; }
        public Guid? UserId { get; private set; } // Создать админ
        public string? Response { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Complaint(Guid playerId, string description, Priority priority = Enums.Priority.Normal)
        {
            Id = Guid.NewGuid();
            PlayerId = playerId;
            Description = description;
            Priority = priority;
            Status = Status.New;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetAdminResponse(Guid adminId, string response)
        {
            UserId = adminId;
            Response = response;
            Status = Status.Completed;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetInProcess()
        {
            Status = Status.InProgress;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
