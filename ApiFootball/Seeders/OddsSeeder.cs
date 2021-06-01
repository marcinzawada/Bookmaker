using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using Infrastructure.Data;

namespace ApiFootball.Seeders
{
    public class OddsSeeder : BaseSeeder
    {
        public OddsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedOdds(int extLeagueId)
        {
            var odds = await _client.DownloadAllOddsByLeagueId(extLeagueId);
            await _context.Odds.AddRangeAsync(odds);
            await _context.SaveChangesAsync();
        }
    }
}
