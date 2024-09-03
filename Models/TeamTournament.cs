namespace R6Ranking.Models {
    public class TeamTournament {

        public int TeamID { get; set; }
        public int TournamentID { get; set; }

        public Team Team { get; set; } = null!;
        public Tournament Tournament { get; set; } = null!;
        
    }
}
