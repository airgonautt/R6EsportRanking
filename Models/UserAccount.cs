using System.ComponentModel.DataAnnotations;

namespace R6Ranking.Models {
    public class UserAccount {

        public int ID { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
