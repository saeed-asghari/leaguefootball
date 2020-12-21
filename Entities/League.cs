using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueFootball.Entities
{
    [Table("League")]
    public  class League
    {
      
        public int LeagueId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime FoundingDate { get; set; }

        public  ICollection<Team> Teams { get; set; }
    }
}
