    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
namespace LeagueFootball.Dtos
{
    public class LeagueDTO 
    {
      
        public string Name { get; set; }

        public DateTime FoundingDate { get; set; }

        public  ICollection<TeamDTO> Teams { get; set; }
    }
}