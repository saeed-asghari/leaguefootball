using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueFootball.Entities
{
    [Table("Player")]
    public class Player
    {
        public int PlayerId { get; set; }

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

      
    }
}
