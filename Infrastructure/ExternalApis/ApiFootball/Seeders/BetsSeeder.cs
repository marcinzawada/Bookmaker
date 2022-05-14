using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class BetsSeeder : BaseSeeder
    {
        private readonly ILogger<BetsSeeder> _logger;

        public BetsSeeder(AppDbContext context, IApiFootballClient client, ILogger<BetsSeeder> logger) : base(context, client)
        {
            _logger = logger;
        }

        public async Task SeedBetsByLeagueId(IEnumerable<int> leagueIds)
        {
            foreach (var leagueId in leagueIds)
            {
                var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == leagueId);

                if (_context.PotentialBets.Any(x => x.LeagueId == league.Id)) 
                    continue;

                var bets = await _client.DownloadAllBetsByLeagueId(leagueId);
                if (bets == null)
                    continue;

                await _context.PotentialBets.AddRangeAsync(bets);
                _logger.LogInformation($"Added {bets.Count} new bets. ExtLeagueId: {leagueId}");
            }
            await _context.SaveChangesAsync();

        }
    }
}
