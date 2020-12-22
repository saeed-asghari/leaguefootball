using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueFootball.Entities
{
        
     [Table("Team")]
    public  class Team
    {
    
        public int TeamId { get; set; }
         [ForeignKey("LeagueID")]
        public int LeagueID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime FoundingDate { get; set; }

        public  ICollection<Player> Players { get; set; }
    }
}