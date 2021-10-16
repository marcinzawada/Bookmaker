using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class BetsSeeder : BaseSeeder
    {
        public BetsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedBetsByLeagueId(int extLeagueId)
        {
            if (! await _context.PotentialBets.AnyAsync())
            {
                var bets = await _client.DownloadAllBetsByLeagueId(extLeagueId);
                await _context.PotentialBets.AddRangeAsync(bets);
                await _context.SaveChangesAsync();
            }
        }
    }
}
