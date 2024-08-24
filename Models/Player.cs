using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class Player {

        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string? Role { get; set; }
        public string? PhotoURL {  get; set; }

        public int? TeamID { get; set; }
        public Team? Team { get; set; }

        public DateTime? DateJoined { get; set; }
        public DateTime? DateLeft { get; set; }
    }
    
}
