namespace R6Ranking.Models {
    public class Team {

        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }

        public string TwitterUrl { get; set; }
        public string PrimaryColor { get; set; }
        
        public string? RegionID { get; set; }
        public Region? Region { get; set; }

        public int CurrentElo { get; set; } = 500;

        public ICollection<Player>? Players { get; set; }
        public ICollection<TeamEloChange>? TeamEloHistory { get; set; } = new List<TeamEloChange>();

        public ICollection<Match>? MatchesAsTeam1 { get; set; } = new List<Match>();
        public ICollection<Match>? MatchesAsTeam2 { get; set; } = new List<Match>();

        public ICollection<TeamOperatorBan>? TeamOperatorBans { get; set; } = new List<TeamOperatorBan>();
        public ICollection<Tournament>? Tournaments { get; set; } = new List<Tournament>();
    }
}
