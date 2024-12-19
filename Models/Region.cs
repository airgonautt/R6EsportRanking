using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class Region {

        public required string RegionID { get; set; }
        public required string RegionName { get; set; }
        public string? LogoUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int AggregatedElo => Teams?.Sum(t => t.CurrentElo) ?? 0;

        
        public ICollection<Team>? Teams { get; set; }
        public ICollection<Tournament>? Tournaments { get; set; }
        public ICollection<RegionEloChange> RegionEloHistory { get; set; } = new List<RegionEloChange>();
    }
}
    
