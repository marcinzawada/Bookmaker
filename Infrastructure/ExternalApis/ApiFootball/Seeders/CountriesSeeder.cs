using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class CountriesSeeder : BaseSeeder
    {
        public CountriesSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedCountries()
        {
            if (!_context.Countries.Any())
            {
                var countries = await _client.DownloadAllCountries();
                await _context.Countries.AddRangeAsync(countries);
                await _context.SaveChangesAsync();
            }
        }
    }
}
