using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using Bookmaker.Api.Data.Data;

namespace ApiFootball.Seeders
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
