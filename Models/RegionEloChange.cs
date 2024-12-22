namespace R6Ranking.Models {
    public class RegionEloChange {

        public int RegionEloHistoryID { get; set; }

        public string RegionID { get; set; }
        public Region Region { get; set; }

        public DateTime ChangeDate { get; set; }

        public int CurrentElo { get; set; }
        public int EloChange { get; set; }

        public string? Note { get; set; }

    }
}
