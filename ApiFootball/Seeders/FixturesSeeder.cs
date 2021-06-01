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

        public async Task SeedFixturesByExtLeagueId(int id)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == id);

            if (!_context.Fixtures.Any(x => x.LeagueId == league.Id))
            {
                var fixtures = await _client.DownloadAllFixturesByLeagueId(id);
                await _context.Fixtures.AddRangeAsync(fixtures);
                await _context.SaveChangesAsync();
            }
        }
    }
}
