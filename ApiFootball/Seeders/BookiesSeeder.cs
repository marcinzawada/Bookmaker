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
