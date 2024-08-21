using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class TeamLogo {
        public int TeamLogoID { get; set; }
        public string? LogoUrl { get; set; }
        public int TeamID { get; set; }

        // Navigation property??
        public required Team Team { get; set; }
    }
}
