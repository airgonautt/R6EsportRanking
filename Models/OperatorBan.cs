using System.Text.Json.Serialization;

namespace R6Ranking.Models {
    public class OperatorBan {

        public int OperatorBanID { get; set; } 
        public string? OperatorName { get; set; }
        public string? OperatorLogo { get; set; }
        public string? OperatorSide { get; set; }

    }
}
