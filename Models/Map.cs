﻿using System.ComponentModel.DataAnnotations;

namespace R6Ranking.Models {
    public class Map {
        
        public int MapID { get; set; }
        [StringLength(20)]
        public string? MapName { get; set; }
        public string? MapPhoto { get; set; }

        public List<Match> Matches { get; set; } = new List<Match>();
    }
}