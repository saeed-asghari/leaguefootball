using LeagueFootball.Dtos;
using LeagueFootball.Interfaces;
using LeagueFootball.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.Authorization;

namespace LeagueFootball.Controller
{

    [Authorize]
    //api/League
    [Route("api/league")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
          private readonly IMapper _mapper;
        private readonly ILeagueService _leagueService;

        public LeaguesController(ILeagueService leagueService, IMapper mapper)
        {
            _leagueService = leagueService;
            _mapper =mapper;
        }

         //Get api/League/
        [HttpGet]
        public async Task<IEnumerable<LeagueDTO>> GetAllLeaguesWithTeamAndPalyer()
        {
            var commandItems = await _leagueService.GetAllLeaguesWithTeamAndPalyer();
            return _mapper.Map<IEnumerable<LeagueDTO>>(commandItems);
        }


       // get  api/League/{id}
        [HttpGet("{id}", Name = "GetLeagueById")]
        public async Task<ActionResult<LeagueDTO>> GetLeagueById(int id)
        {
            var leagueItem = await _leagueService.GetLeagueById(id);
            if (leagueItem != null)
            {
                return Ok(_mapper.Map<LeagueDTO>(leagueItem));
            }
            return NotFound();
        }
        
  
    }
    
}
