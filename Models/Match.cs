using R6Ranking.Data;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace R6Ranking.Models {
    public class Match {

        public int MatchID { get; set; }
        public string? MatchName { get; set; }
        public DateTime MatchDate { get; set; }

        public int Team1ID { get; set; }
        public Team? Team1 { get; set; }
        public int Team1Score { get; set; }

        public int Team2ID { get; set; }
        public Team? Team2 { get; set; }
        public int Team2Score { get; set; }

        [ForeignKey("MapID")]
        public int MapID { get; set; }        
        public Map Map { get; set; }

        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; }

        public ICollection<TeamEloChange>? TeamEloChanges { get; set; }
        public ICollection<MatchOperatorBan>? MatchOperatorBans { get; set; }

    }
}
