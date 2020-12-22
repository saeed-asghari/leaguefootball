using System.Collections.Generic;
using System.Linq;
using LeagueFootball.Entities;
using LeagueFootball.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LeagueFootball.Helpers
{
    public class SqlTeamRepo : ITeamService
    {
        private readonly LeaguesDataContext _context;
        public SqlTeamRepo(LeaguesDataContext context)
        {
            _context = context;
        }

        public void CreateTeam(Team cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Teams.Add(cmd);
        }

    
        public async Task<Team> GetTeamById(int id)
        {
            return await _context.Teams.FirstOrDefaultAsync(p => p.TeamId == id);
        }


        public async Task<IEnumerable<Team>> GetAllTeams()
        {
               var query = await _context.Teams.ToListAsync();
              return query;
        }
        public void UpdateTeam(Team cmd)
        {
            _context.Teams.Update(cmd);
        }

        public void DeleteTeam(Team cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Teams.Remove(cmd);
        }

      public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}