using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class Region {

        public required string RegionID { get; set; }
        public required string RegionName { get; set; }
        public string? LogoUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Precision(7, 2)]
        public decimal AggregatedElo => Teams?.Sum(t => t.CurrentElo) ?? 0;

        //public decimal AggregatedElo => Teams?.Where(t =>
        //    t.CurrentElo != null).Sum(t => t.CurrentElo) ?? 0;//check if the teams collection is not null and returns 0 otherwise

        public ICollection<Team>? Teams { get; set; }
        public ICollection<Tournament>? Tournaments { get; set; }
        public ICollection<RegionEloChange> RegionEloHistory { get; set; } = new List<RegionEloChange>();
    }
}
    
