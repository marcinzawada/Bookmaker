using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class LabelsSeeder : BaseSeeder
    {
        public LabelsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedLabels()
        {
            if (!_context.Labels.Any())
            {
                var labels = await _client.DownloadAllLabels();
                await _context.Labels.AddRangeAsync(labels);
                await _context.SaveChangesAsync();
            }
        }
    }
}
