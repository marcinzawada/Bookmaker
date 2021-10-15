using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class SportSeeder : BaseSeeder
    {
        public SportSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedSport()
        {
            var isFootballInBase = await _context.Sports.AnyAsync(x => x.Name == "Football");
            if (!isFootballInBase)
            {
                var football = new Sport
                {
                    Name = "Football"
                };
                await _context.Sports.AddAsync(football);
                await _context.SaveChangesAsync();
            }
        }
    }
}
