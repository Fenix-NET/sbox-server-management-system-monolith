using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class CharacterItem
    {
        public Guid CharacterId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime AcquiredAt { get; set; }
    }
}
