using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class Team {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public string? RegionID { get; set; }
        public string? RegionName { get; set; }
        public string? Coach { get; set; }

        [Precision(7,2)]
        public decimal CurrentElo { get; set; } = 500;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Region? Region { get; set; }
        public TeamLogo? Logo { get; set; } // Relationship with TeamLogo table


        public ICollection<Player>? Players { get; set; }
        public ICollection<TeamEloHistory>? TeamEloHistories { get; set; }
        public ICollection<Match>? TeamMatches { get; set; }
        
    }
}
