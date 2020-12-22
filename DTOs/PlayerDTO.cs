using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LeagueFootball.Dtos
{
    public class PlayerDTO 
    {

        public string FirstName { get; set; }
    
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}