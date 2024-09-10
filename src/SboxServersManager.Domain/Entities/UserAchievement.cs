using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class UserAchievement
    {
        public Guid UserId { get; private set; }
        public Guid AchievementId { get; private set; }
        public DateTime AchievedAt { get; private set; }  // Дата получения достижения

    }
}
