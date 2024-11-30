using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace R6Ranking.Models
{
    public class Match {

        public int MatchID { get; set; }
        public string? MatchName { get; set; }

        public int Team1ID { get; set; }
        public Team? Team1 { get; set; }
        public int Team1Score { get; set; }

        public int Team2ID { get; set; }
        public Team? Team2 { get; set; }
        public int Team2Score { get; set; }

        public DateTime MatchDate { get; set; }

        //navigation
        public int MapID { get; set; }        
        public Map Map { get; set; }
        
        public int TournamentID { get; set; }
        public Tournament? Tournament { get; set; }

        public ICollection<TeamOperatorBan> TeamOperatorBans { get; set; } = new List<TeamOperatorBan>();

    }
}
