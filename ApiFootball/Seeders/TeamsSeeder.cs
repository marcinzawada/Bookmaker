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
    public class TeamsSeeder : BaseSeeder
    {
        public TeamsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedTeams()
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == 2655);

            if (_context.Teams.Count(x => x.Leagues.Any(y => y.LeagueId == league.Id)) == 0)
            {
                var teams = await _client.DownloadTeamsByLeagueId(2655);
                await _context.Teams.AddRangeAsync(teams);
                await _context.SaveChangesAsync();
            }
        }
    }
}
