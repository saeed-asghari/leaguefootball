using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueFootball.Entities;
namespace LeagueFootball.Interfaces
{
    public interface ITeamService
    {

        Task<IEnumerable<Team>> GetAllTeams();
        Task<Team> GetTeamById(int id);

        void  CreateTeam(Team cmd);

        void UpdateTeam(Team cmd);
        void DeleteTeam(Team cmd);
        bool SaveChanges();
    }
}