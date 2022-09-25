using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class RoundsSeeder : BaseSeeder
    {
        private readonly ILogger<RoundsSeeder> _logger;

        public RoundsSeeder(AppDbContext context, IApiFootballClient client, ILogger<RoundsSeeder> logger) : base(context, client)
        {
            _logger = logger;
        }

        public async Task SeedRoundsByExtLeagueId(IEnumerable<int> leagueIds)
        {
            foreach (var leagueId in leagueIds)
            {
                var league = _context.Leagues.FirstOrDefault(x => x.ExtLeagueId == leagueId);

                if (league == null)
                {
                    _logger.LogError($"League not found. ExtLeagueId: {leagueId}");
                    continue;
                }

                if (_context.Rounds.Any(x => x.LeagueId == league.Id))
                    continue;

                var rounds = await _client.DownloadAllRoundsByLeagueId(leagueId);
                await _context.Rounds.AddRangeAsync(rounds);
            }
            await _context.SaveChangesAsync();

        }
    }
}
