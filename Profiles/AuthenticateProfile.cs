using AutoMapper;
using leaguefootball.DTOs;
using LeagueFootball.RequestModels;

namespace leaguefootball.Profiles
{
    public class AuthenticateProfile :Profile
    {
        public AuthenticateProfile()
        {
            CreateMap<AuthenticateResponse, AuthenticateResponseDTO>();
        }
    }
}
