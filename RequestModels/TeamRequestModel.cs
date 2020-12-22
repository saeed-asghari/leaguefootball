using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeagueFootball.Entities;

namespace LeagueFootball.RequestModels
{
    public  class TeamRequestModel
    {
    
        [Required]
        public int LeagueID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime FoundingDate { get; set; }

         public  ICollection<Player> Players { get; set; }

    }
    public class TeamUpdateRequestModel : TeamRequestModel
    {
      
    }

}