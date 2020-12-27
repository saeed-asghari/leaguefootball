using System.ComponentModel.DataAnnotations;

namespace LeagueFootball.RequestModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}