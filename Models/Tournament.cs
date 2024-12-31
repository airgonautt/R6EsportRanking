namespace R6Ranking.Models {
    public class Tournament {

        public int TournamentID { get; set; }
        public string? TournamentName { get; set; }
        public string? TournamentLocation { get; set; }
        public string? TournamentLogo { get; set; } 
        public bool IsCurrentTournament { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? WinnerTeamID { get; set; }
        public Team? WinnerTeam { get; set; }

        public string? RegionID { get; set; }
        public Region? Region { get; set; }

        public ICollection<Team>? Teams { get; set; } = new List<Team>();
        public Trophy? Trophy { get; set; }
    }
}
