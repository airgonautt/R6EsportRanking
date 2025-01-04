namespace R6Ranking.Models {
    public class TournamentTeam {
        public int TournamentTeamID { get; set; } 

        // Foreign Keys
        public int TournamentID { get; set; }
        public Tournament? Tournament { get; set; }

        public int TeamID { get; set; }
        public Team? Team { get; set; }

    }
}
