﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiFootball.Client;
using Domain.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiFootball.Seeders
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