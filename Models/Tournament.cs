namespace R6Ranking.Models
{
    public class Tournament {

        public int TournamentID { get; set; }
        public string? Name { get; set; }

        public string? Location { get; set; }
        public string? Logo { get; set; } // URL to the logo

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? WinnerTeamID { get; set; }
        public Team? WinnerTeam { get; set; }

        public string? RegionID { get; set; }
        public Region? Region { get; set; } // Relationship with the region where the tournament takes place


        // Navigation property for related Matches
        public ICollection<Match>? Matches { get; set; }
    }
}
