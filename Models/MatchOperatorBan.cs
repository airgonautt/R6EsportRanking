namespace R6Ranking.Models {
    public class MatchOperatorBan {

        public int MatchID { get; set; }
        public Match Match { get; set; }

        public int OperatorBanID { get; set; }
        public OperatorBan OperatorBan { get; set; }
    }
}
