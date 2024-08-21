using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace R6Ranking.Models {
    public class PlayerEloHistory {

        [Key]
        public int EloHistoryID { get; set; }

        public int PlayerID { get; set; }
        public int MatchID { get; set; }
        [Precision(7, 2)]
        public decimal OldElo { get; set; }
        [Precision(7, 2)]
        public decimal NewElo { get; set; }
        [Precision(7, 2)]
        public decimal EloChange { get; set; }
        public DateTime ChangeDate { get; set; }
        public required Player Player { get; set; }
        public Match? Match { get; set; }


    }
}
