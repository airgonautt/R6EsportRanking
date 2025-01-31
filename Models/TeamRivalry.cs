using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R6Ranking.Models {
    public class TeamRivalry {

        public int TeamRivalryID { get; set; }

        [Required]
        public int TeamID { get; set; }
        [Required]
        public int RivalTeamID { get; set; }

        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
