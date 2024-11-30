using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class TeamEloChange {

        public int TeamEloChangeID { get; set; }

        public int TeamID { get; set; }
        public Team? Team { get; set; }

        public int? RivalTeamID { get; set; }
        public Team? RivalTeam { get; set; }

        [Precision(7, 2)]
        public decimal CurrentElo { get; set; }
        [Precision(7, 2)]
        public decimal EloChange { get; set; }

        public DateTime Date { get; set; }
        public string? Note { get; set; }
    }
}
