using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class RegionEloChange {

        public int RegionEloHistoryID { get; set; }

        public string RegionID { get; set; }
        public Region Region { get; set; }

        public DateTime ChangeDate { get; set; }

        [Precision(7, 2)]
        public decimal CurrentElo { get; set; }
        [Precision(7, 2)]
        public decimal EloChange { get; set; }
        public string? Note { get; set; }

    }
}
