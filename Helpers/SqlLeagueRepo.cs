using System.Collections.Generic;
using System.Linq;
using LeagueFootball.Entities;
using LeagueFootball.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LeagueFootball.Helpers
{
    public class SqlLeagueRepo : ILeagueService
    {
        private readonly LeaguesDataContext _context;
        public SqlLeagueRepo(LeaguesDataContext context)
        {
            _context = context;
        }

     

        public async Task<IEnumerable<League>> GetAllLeaguesWithTeamAndPalyer()
        {
               var query = await _context.Leagues.Include(i => i.Teams)
                                          .ThenInclude(it => it.Players).ToListAsync();
           
              return query;
        }

        public async Task<League> GetLeagueById(int id)
        {
            return await _context.Leagues.FirstOrDefaultAsync(p => p.LeagueID == id);
        }
     
    }
}