namespace R6Ranking.Models
{
    public class Tournament {

        public string TournamentID { get; set; } = Guid.NewGuid().ToString(); // Primary key
        public required string Name { get; set; }
        public string? Location { get; set; }
        public required string Logo { get; set; } // URL to the logo
        public string? Winner { get; set; } // Nullable Winner
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation property for related Matches
        public ICollection<Match>? Matches { get; set; }
    }
}
