using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiFootball.Seeders
{
    public class FixturesSeeder : BaseSeeder
    {
        public FixturesSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedFixtures()
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == 2655);

            if (_context.Fixtures.Count(x => x.LeagueId == league.Id) == 0)
            {
                var fixtures = await _client.DownloadAllFixturesByLeagueId(2655);
                await _context.Fixtures.AddRangeAsync(fixtures);
                await _context.SaveChangesAsync();
            }
        }
    }
}
