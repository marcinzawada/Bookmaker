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
    public class OddsSeeder : BaseSeeder
    {
        public OddsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedOddsByLeagueId(int extLeagueId)
        {
            if (! await _context.Odds.AnyAsync())
            {
                var odds = await _client.DownloadAllOddsByLeagueId(extLeagueId);
                await _context.Odds.AddRangeAsync(odds);
                await _context.SaveChangesAsync();
            }
        }
    }
}
