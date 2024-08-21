using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class TeamEloHistory {

        public int TeamEloHistoryID { get; set; }
        public int TeamID { get; set; }
        
        public int? RivalTeamID { get; set; }
        public string? RivalTeamName { get; set; }
        public Match? Match { get; set; }

        public DateTime Date { get; set; }
        public int? MatchID { get; set; }
        public string? TournamentName {  get; set; }

        [Precision(7, 2)]
        public decimal CurrentElo { get; set; }
        [Precision(7, 2)]
        public decimal EloChange { get; set; }

        // Navigation properties
        public Team Team { get; set; }
        public Team? RivalTeam { get; set; } // Navigation property for RivalTeam

    }
}
