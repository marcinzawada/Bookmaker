using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using Domain.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiFootball.Seeders
{
    public class LeaguesSeeder : BaseSeeder
    {
        public LeaguesSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedLeagues()
        {
            if (!_context.Leagues.Any())
            {
                var leagues = await _client.DownloadAllLeagues();
                await _context.Leagues.AddRangeAsync(leagues);
                await _context.SaveChangesAsync();
            }
        }
    }
}
