using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class TeamsSeeder : BaseSeeder
    {
        public TeamsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedTeamsByExtLeagueId(IEnumerable<int> leagueIds)
        {
            foreach (var leagueId in leagueIds)
            {
                var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == leagueId);

                if (_context.Teams.Any(x => x.Leagues.Any(y => y.LeagueId == league.Id))) 
                    continue;

                var teams = await _client.DownloadTeamsByLeagueId(leagueId);
                await _context.Teams.AddRangeAsync(teams);
            }

            await _context.SaveChangesAsync();

            //var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == id);

            //if (_context.Teams.Count(x => x.Leagues.Any(y => y.LeagueId == league.Id)) == 0)
            //{
            //    var teams = await _client.DownloadTeamsByLeagueId(id);
            //    await _context.Teams.AddRangeAsync(teams);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
