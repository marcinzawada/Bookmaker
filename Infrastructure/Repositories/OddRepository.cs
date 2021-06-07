using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OddRepository : GenericRepository<Odd>, IOddRepository
    {
        public OddRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Odd>> GetOddsWithFixturesAndTeamsByLeagueIdAsync(int leagueId, CancellationToken cancellationToken)
        {
            return await _context.Odds
                .Include(x => x.Fixture)
                .ThenInclude(x => x.AwayTeam)
                .Include(x => x.Fixture)
                .ThenInclude(x => x.HomeTeam)
                .Where(x => x.LeagueId == leagueId)
                .ToListAsync(cancellationToken);
        }
    }
}
