namespace R6Ranking.Models {
    public class OperatorBan {

        public int OperatorBanID { get; set; } 
        public string OperatorName { get; set; }

        public int MatchID { get; set; }
        public Match? Match { get; set; }
    }
}
