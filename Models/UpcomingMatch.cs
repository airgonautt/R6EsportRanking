namespace R6Ranking.Models {
    public class UpcomingMatch {

        public int FutureMatchID { get; set; }
        public string? MatchName { get; set; }
        public string? VODURL { get; set; }

        public int Team1ID { get; set; }
        public Team? Team1 { get; set; }

        public int Team2ID { get; set; }
        public Team? Team2 { get; set; }

        public DateTime MatchDate { get; set; }
    }
}
