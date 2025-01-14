namespace R6Ranking.Models {
    public class UserAccountPolicy {
        public int ID {  get; set; }

        public int UserAccountID {  get; set; }
        public string? UserPolicy { get; set; }
        public bool IsEnabled {  get; set; }
    }
}
