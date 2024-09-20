using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SboxServersManager.Domain.Enums;

namespace SboxServersManager.Domain.Entities
{
    public class Complaint : BaseEntity
    {
        public string Description { get; private set; }
        public Guid AuthorId { get; private set; }
        public Priority? Priority { get; private set; }
        public Status Status { get; private set; }
        public string? AdminName { get; private set; } // Создать админ
        public string? Response { get; private set; }

        public Complaint(Guid authorId, string description, Priority priority = Enums.Priority.Normal)
        {
            Id = Guid.NewGuid();
            AuthorId = authorId;
            Description = description;
            Priority = priority;
            Status = Status.New;
            CreatedDate = DateTime.UtcNow;
        }

        public void SetAdminResponse(string adminName, string response)
        {
            AdminName = adminName;
            Response = response;
            Status = Status.Completed;
            UpdatedDate = DateTime.UtcNow;
        }
        public void SetInProcess()
        {
            Status = Status.InProgress;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
