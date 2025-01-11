namespace R6Ranking.Models {
    public class Region {

        public required string RegionID { get; set; }
        public required string RegionName { get; set; }

        public string? LogoUrl { get; set; }
        public string? SocialUrl { get; set; }
        public string? RegionMap { get; set; }

        public int RegionalElo { get; set; } = 0;

        public ICollection<Team>? Teams { get; set; }
        public ICollection<Tournament>? Tournaments { get; set; }
        public ICollection<RegionEloChange> RegionEloHistory { get; set; } = new List<RegionEloChange>();
    }
}

