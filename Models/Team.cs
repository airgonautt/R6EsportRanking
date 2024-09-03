using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class Team {
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public string? LogoUrl { get; set; }

        public string? RegionID { get; set; }
        public Region? Region { get; set; }

        [Precision(7,2)]
        public decimal CurrentElo { get; set; } = 500;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Player>? Players { get; set; }
        public ICollection<TeamEloChange>? TeamEloChanges { get; set; }

        public ICollection<Match> MatchesAsTeam1 { get; set; } = new List<Match>();
        public ICollection<Match> MatchesAsTeam2 { get; set; } = new List<Match>();

        public ICollection<Tournament>? WonTournaments { get; set; }
        public ICollection<TeamTournament>? TournamentsIn { get; } = [];
    }
}
