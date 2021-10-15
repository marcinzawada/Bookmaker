using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class BookiesSeeder : BaseSeeder
    {
        public BookiesSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedBookies()
        {
            if (! await _context.Bookies.AnyAsync())
            {
                var bookies = await _client.DownloadAllBookies();
                await _context.Bookies.AddRangeAsync(bookies);
                await _context.SaveChangesAsync();
            }
        }
    }
}
