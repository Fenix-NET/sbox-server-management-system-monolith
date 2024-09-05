using Microsoft.AspNetCore.Identity;
using SboxServersManager.Domain.Entities;

namespace SboxServersManager.Infrastructure.Identity.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Player? Player { get; set; }
        public decimal AccauntBalance { get; set; } = 0;
    }
}
