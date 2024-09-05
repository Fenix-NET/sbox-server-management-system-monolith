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
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Player Author { get; set; }
        public Priority Priority { get; set; }
        public ComplaintStatus Status { get; set; }
        public string Responsible { get; set; } // Создать админ
        public string Answer { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
