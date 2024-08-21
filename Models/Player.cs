using Microsoft.EntityFrameworkCore;

namespace R6Ranking.Models {
    public class Player {
        public int PlayerID { get; set; }
        public required string PlayerName { get; set; }
        public int TeamID { get; set; }
        public string? Role { get; set; }
        [Precision(7, 2)]
        public decimal CurrentElo { get; set; } = 500;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Team? Team { get; set; }
        public ICollection<PlayerEloHistory>? PlayerEloHistories { get; set; }
    }
    
}
