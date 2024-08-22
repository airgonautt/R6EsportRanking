using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class Team {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public int? RegionID { get; set; }
        public string? RegionName { get; set; }
        public string? Coach { get; set; }

        [Precision(7,2)]
        public decimal CurrentElo { get; set; } = 500;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Region? Region { get; set; }
        public TeamLogo? Logo { get; set; } // Relationship with TeamLogo table


        public ICollection<Player>? Players { get; set; }
        public ICollection<TeamEloChange>? TeamEloChanges { get; set; }
        public ICollection<Match> MatchesAsTeam1 { get; set; } = new List<Match>();
        public ICollection<Match> MatchesAsTeam2 { get; set; } = new List<Match>();
        public ICollection<Tournament>? WonTournaments { get; set; }

    }
}
