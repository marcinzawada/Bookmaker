using Bookmaker.Api.Data.Data;
using Bookmaker.ApiFootball.Client;
using Bookmaker.ApiFootball.DataInitialization;
using Bookmaker.ApiFootball.DTOs;
using Bookmaker.ApiFootball.DTOs.Countries;
using Bookmaker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class CountriesAFDataInitialization : BaseAFDataInitialization
    {
        private readonly ILogger<CountriesAFDataInitialization> _logger;

        public CountriesAFDataInitialization(ILogger<CountriesAFDataInitialization> logger,
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
                await _client.DownloadAllIResources<DTOsHolder<Country>, Country>("/countries");


            _context.Countries.AddRange(countries);
            await _context.SaveChangesAsync();

            return countriesInBase;
        }
    }
}
