using Bookmaker.ApiFootball.DataInitialization;
using Bookmaker.ApiFootball.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFootball.Client;
using ApiFootball.DTOs;
using Domain.Data;
using Domain.Entities;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class CountriesAfDataInitialization : BaseAfDataInitialization
    {
        private readonly ILogger<CountriesAfDataInitialization> _logger;

        public CountriesAfDataInitialization(ILogger<CountriesAfDataInitialization> logger,
            AppDbContext context, IApiFootballClient client) : base(context, client)
        {
            _logger = logger;
        }


        private async Task<List<Country>> DownloadAllFirstTime()
        {
            var countriesInBase = await _context.Countries.ToListAsync();
            if (countriesInBase.Count != 0)
                return countriesInBase;

            var countries = 
                await _client.DownloadAllIResources<DtoHolder<Country>, Country>("/countries");


            _context.Countries.AddRange(countries);
            await _context.SaveChangesAsync();

            return countriesInBase;
        }
    }
}
