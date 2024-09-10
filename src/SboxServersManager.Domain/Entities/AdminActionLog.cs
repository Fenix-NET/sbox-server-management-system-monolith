using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class AdminActionLog
    {
        public Guid Id { get; private set; }
        public Guid AdminId { get; private set; }   // Id Админа, который выполнил действие.
        public string Action { get; private set; }  // Описание действия.
        public DateTime Timestamp { get; private set; }  // Время действия
        public string? AdditionalInfo { get; private set; }  // Дополнительная информация
    }
}
