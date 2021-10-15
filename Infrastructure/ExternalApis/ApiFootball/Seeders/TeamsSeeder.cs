using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class TeamsSeeder : BaseSeeder
    {
        public TeamsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedTeamsByExtLeagueId(int id)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(x => x.ExtLeagueId == id);

            if (_context.Teams.Count(x => x.Leagues.Any(y => y.LeagueId == league.Id)) == 0)
            {
                var teams = await _client.DownloadTeamsByLeagueId(id);
                await _context.Teams.AddRangeAsync(teams);
                await _context.SaveChangesAsync();
            }
        }
    }
}
