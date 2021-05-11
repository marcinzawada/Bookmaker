using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiFootball.Seeders
{
    public class SeasonsSeeder : BaseSeeder
    {
        public SeasonsSeeder(AppDbContext context, IApiFootballClient client) : base(context, client)
        {
        }

        public async Task SeedSeasons()
        {
            if (!_context.Seasons.Any())
            {
                var seasons = new List<Season>();
                for (var i = 2000; i < 2099; i++)
                {
                    seasons.Add(new Season{Year = i});
                }
                await _context.Seasons.AddRangeAsync(seasons);
                await _context.SaveChangesAsync();
            }
        }
    }
}
