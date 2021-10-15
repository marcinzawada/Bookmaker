using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
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
