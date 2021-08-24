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
    public class BetsSeeder : BaseSeeder
    {
        public BetsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedBetsByLeagueId(int extLeagueId)
        {
            if (! await _context.Bets.AnyAsync())
            {
                var bets = await _client.DownloadAllBetsByLeagueId(extLeagueId);
                await _context.Bets.AddRangeAsync(bets);
                await _context.SaveChangesAsync();
            }
        }
    }
}
