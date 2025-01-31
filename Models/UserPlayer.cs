namespace R6Ranking.Models {
    public class UserPlayer {

        public int UserPlayerID { get; set; }

        public string? PlayerName { get; set; }
        public string? Role { get; set; }
        public string? PhotoURL { get; set; }
        public string? CardURL { get; set; }
        public string? FlavorText { get; set; }
        public int? SkillRating { get; set; }
        public int? EloRating { get; set; }

        public int? Kills { get;set; } 
        public int? Deaths { get; set; }
        public float? KOST {  get; set; }   
        public int? Entry { get; set; }
        public int? KPR { get; set; }
        public int? Plant { get; set; }

        public int? UserID { get; set; }
        public UserAccount? User { get; set; }

        public int? CountryID { get; set; }
        public OriginCountry? OriginCountry { get; set; }
    }
}
