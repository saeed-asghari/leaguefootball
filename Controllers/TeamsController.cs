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
using LeagueFootball.RequestModels;

namespace LeagueFootball.Controller
{

    //api/team
    [Route("api/team")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper =mapper;
        }

        //Get api/team
        [HttpGet]
        public async Task<IEnumerable<TeamDTO>> GetAllTeams()
        {
            var teamItems = await _teamService.GetAllTeams();
            return _mapper.Map<IEnumerable<TeamDTO>>(teamItems);
        }       
        //api/team/{id}
        [HttpGet("{id}", Name = "GetTeamById")]
        public async Task<ActionResult<TeamDTO>> GetTeamById(int id)
        {
            var teamItem = await _teamService.GetTeamById(id);
            if (teamItem != null)
            {
                return Ok(_mapper.Map<TeamDTO>(teamItem));
            }
            return NotFound();
        }


      //POST api/team
        [HttpPost]
        public  ActionResult<TeamDTO> CreateTeam(TeamRequestModel teamRequestModel)
        {
            var teamModel = _mapper.Map<Team>(teamRequestModel);
            _teamService.CreateTeam(teamModel);
            _teamService.SaveChanges();
            var teamDTO = _mapper.Map<TeamDTO>(teamModel);
            
            //return  CreatedAtRoute(nameof(GetTeamById), new { TeamId = teamDTO.TeamId }, teamDTO);
           return Ok(teamDTO);

        }

        
       // PUT api/team/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeam(int id, TeamUpdateRequestModel teamUpdateRequestModel)
        {
            var teamModelFromRepo = await _teamService.GetTeamById(id);
            if (teamModelFromRepo == null)
            {
                return NotFound();

            }
            _mapper.Map(teamUpdateRequestModel, teamModelFromRepo);
            _teamService.UpdateTeam(teamModelFromRepo);
            _teamService.SaveChanges();
            return NoContent();

        }
       //Delete  api/team/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            var teamModelFromRepo = await _teamService.GetTeamById(id);
            if (teamModelFromRepo == null)
            {
                return NotFound();
            }
            _teamService.DeleteTeam(teamModelFromRepo);
             _teamService.SaveChanges();
            return NoContent();
        }

    }
}      