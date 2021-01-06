using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueFootball.Entities;
using LeagueFootball.RequestModels;
namespace LeagueFootball.Interfaces
{
    public interface IUserService
    {

        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}