namespace R6Ranking.Models {
    public class MapStat {

        public int MapStatsID { get; set; }

        public int TeamID { get; set; }
        public Team? Team { get; set; }

        public int MapID { get; set; }
        public Map? Map { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public double WinRate => Wins + Losses == 0 ? 0 : (double)Wins / (Wins + Losses) * 100;
    }
}
