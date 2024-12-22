namespace R6Ranking.Models {
    public class OriginCountry {

        public int CountryID { get; set; }

        public string? CountryName { get; set; }
        public string? CountryFlag { get; set; }

        public ICollection<Player>? CountryPlayers { get; set; } = new List<Player>();
    }
}
