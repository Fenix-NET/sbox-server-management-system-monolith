using Microsoft.AspNetCore.Identity;
using SboxServersManager.Domain.Entities;

namespace SboxServersManager.Infrastructure.Identity.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Player? Player { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal AccauntBalance { get; set; } = 0;
        public string? SteamId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
