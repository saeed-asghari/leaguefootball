using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueFootball.Entities;
using LeagueFootball.RequestModels;
namespace LeagueFootball.Interfaces
{
    public interface IAuthenticate
    {
        AuthenticateResponse Authenticate(AuthenticateRequestModel model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
           User GetById(int id);
    }
}