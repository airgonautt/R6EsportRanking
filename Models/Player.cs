using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace R6Ranking.Models {
    public class Player {

        public int PlayerID { get; set; }

        public string? PlayerName { get; set; }
        public string? Role { get; set; }
        public string? PhotoURL {  get; set; }
        public string? CardURL { get; set; }
        public string? FlavorText { get; set; }
        public int? SkillRating { get; set; }

        public int? TeamID { get; set; }
        public Team? Team { get; set; }

        public int? CountryID { get; set; } 
        public Country? Country { get; set; }

        public DateTime? DateJoined { get; set; }
        public DateTime? DateLeft { get; set; }
    }
        
}
