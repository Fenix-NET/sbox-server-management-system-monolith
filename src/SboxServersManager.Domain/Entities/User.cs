using Microsoft.AspNetCore.Identity;

namespace SboxServersManager.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Player? Player { get; set; }
        public decimal AccauntBalance { get; set; } = 0;
    }
}
