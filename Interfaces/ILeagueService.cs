using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueFootball.Entities;
namespace LeagueFootball.Interfaces
{
    public interface ILeagueService 
    {

        Task<IEnumerable<League>> GetAllLeaguesWithTeamAndPalyer();
        Task<League> GetLeagueById(int Id);


    }
}