using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Achievement : BaseEntity
    {
        public string Name { get; private set; }       // Название достижения
        public string Description { get; private set; } // Описание достижения
        public string EntityType { get; private set; }  // Тип сущности (например, User, Character или Admin)
        public string? Image {  get; private set; }
    }
}
