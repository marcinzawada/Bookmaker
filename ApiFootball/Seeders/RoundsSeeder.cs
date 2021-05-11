using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using ApiFootball.Mappers;
using Bookmaker.Api.Data.Data;
using Microsoft.Extensions.Logging;

namespace ApiFootball.Seeders
{
    public class RoundsSeeder : BaseSeeder
    {
        private readonly ILogger<RoundsSeeder> _logger;

        public RoundsSeeder(AppDbContext context, IApiFootballClient client, ILogger<RoundsSeeder> logger) : base(context, client)
        {
            _logger = logger;
        }

        public async Task SeedRounds()
        {
            var league = _context.Leagues.FirstOrDefault(x => x.ExtLeagueId == 2655);
            
            if (league == null)
                _logger.LogError($"League not found. ExtLeagueId: {2655}");
            
            if (!_context.Rounds.Any(x => x.LeagueId == league.Id))
            {
                var rounds = await _client.DownloadAllRoundsByLeagueId(2655);
                await _context.Rounds.AddRangeAsync(rounds);
                await _context.SaveChangesAsync();
            }
        }
    }
}
