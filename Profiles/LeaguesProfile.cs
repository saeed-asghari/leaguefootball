using AutoMapper;
using LeagueFootball.Entities;
using LeagueFootball.Dtos;
using LeagueFootball.RequestModels;
namespace LeagueFootball.Profiles
{
    public class LeaguesProfile :Profile
    {
        public LeaguesProfile()
        {
            //Source -> Target
            CreateMap<League, LeagueDTO>();
            CreateMap<Team, TeamDTO>();
            CreateMap<Player, PlayerDTO>();

            CreateMap<TeamRequestModel,Team>();
            CreateMap<TeamUpdateRequestModel,Team>();

            CreateMap<League, LeagueDTO>();

            //CreateMap<User, AuthenticateDTO>();


        }
    }
}