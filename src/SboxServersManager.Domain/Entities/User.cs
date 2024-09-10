using Microsoft.AspNetCore.Identity;

namespace SboxServersManager.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public List<Character>? Characters { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsVip { get; set; }
        public DateTime VipStartDate { get; set; }
        public DateTime VipEndDate { get; set; }
        public List<Achievement>? Achievements { get; set; }
        public decimal AccauntBalance { get; set; } = 0;
        public int? NumberPurchases { get; set; }
        public decimal? TotalMoneySpent { get; set; }
        public string? SteamId { get; set; }
        public List<Complaint> Complaints { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
