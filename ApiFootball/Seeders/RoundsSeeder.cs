using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using ApiFootball.Mappers;
using Infrastructure.Data;
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

        public async Task SeedRoundsByExtLeagueId(int id)
        {
            var league = _context.Leagues.FirstOrDefault(x => x.ExtLeagueId == id);
            
            if (league == null)
                _logger.LogError($"League not found. ExtLeagueId: {id}");
            
            if (!_context.Rounds.Any(x => x.LeagueId == league.Id))
            {
                var rounds = await _client.DownloadAllRoundsByLeagueId(id);
                await _context.Rounds.AddRangeAsync(rounds);
                await _context.SaveChangesAsync();
            }
        }
    }
}
