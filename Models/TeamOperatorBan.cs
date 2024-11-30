using System.Text.Json.Serialization;

namespace R6Ranking.Models {
    public class TeamOperatorBan {
        public int TeamOperatorBanID { get; set; } // Primary Key

        // Foreign Keys
        public int TeamID { get; set; }
        public Team? Team { get; set; } 

        public int OperatorBanID { get; set; }
        public OperatorBan? OperatorBan { get; set; }

        [JsonIgnore]
        public Match? Match { get; set; }
        public int MatchId { get; set; }

    }
}
