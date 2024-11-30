namespace R6Ranking.Models {
    public class Trophy {

        public int TrophyID {  get; set; }
        public string? TrophyName { get; set; }
        public string? TrophyPhotoURL {  get; set; }

        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; } = null!;
    }
}
