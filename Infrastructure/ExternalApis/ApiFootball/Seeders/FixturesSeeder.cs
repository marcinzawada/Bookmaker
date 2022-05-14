using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class FixturesSeeder : BaseSeeder
    {
        public FixturesSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedFixturesByExtLeagueId(IEnumerable<int> leagueIds)
        {
            foreach (var leagueId in leagueIds)
            {

                var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == leagueId);

                if (_context.Fixtures.Any(x => x.LeagueId == league.Id))
                    continue;

                var fixtures = await _client.DownloadAllFixturesByLeagueId(leagueId);
                await _context.Fixtures.AddRangeAsync(fixtures);
            }
            await _context.SaveChangesAsync();


            //var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == id);

            //if (!_context.Fixtures.Any(x => x.LeagueId == league.Id))
            //{
            //    var fixtures = await _client.DownloadAllFixturesByLeagueId(id);
            //    await _context.Fixtures.AddRangeAsync(fixtures);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
