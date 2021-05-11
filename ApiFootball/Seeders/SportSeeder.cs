using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiFootball.Seeders
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
