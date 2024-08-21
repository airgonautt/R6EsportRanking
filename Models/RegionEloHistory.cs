using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class RegionEloHistory {
        public int RegionEloHistoryID { get; set; }
        public int RegionID { get; set; }
        [Precision(7, 2)]
        public decimal OldElo { get; set; }
        [Precision(7, 2)]
        public decimal NewElo { get; set; }
        [Precision(7, 2)]
        public decimal EloChange { get; set; }
        public DateTime ChangeDate { get; set; }
        public Region? Region { get; set; }
    }
}
