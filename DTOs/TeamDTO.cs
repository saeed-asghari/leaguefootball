using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueFootball.Dtos
{
  public class TeamDTO 
    {
       public int TeamId { get; set; }
        public string Name { get; set; }

        public DateTime FoundingDate { get; set; }

        public  ICollection<PlayerDTO> Players { get; set; }
    }
}