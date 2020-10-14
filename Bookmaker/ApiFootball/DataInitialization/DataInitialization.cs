using Bookmaker.ApiFootball.Client;
using Bookmaker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class DataInitialization : BaseAFDataInitialization, IDataInitialization
    {
        private readonly ILogger<DataInitialization> _logger;

        public DataInitialization(ILogger<DataInitialization> logger,
            AppDbContext context, IApiFootballClient client) : base(context, client)
        {
            _logger = logger;
        }


        public async Task<List<TEntity>> DownloadAllFirstTime<DTO,TEntity>() where TEntity : class
        {
            var itemsInBase = await  _context.Set<TEntity>().ToListAsync();
            if (itemsInBase.Count != 0)
                return itemsInBase;

            //var container =
                //await _client.DownloadAllIResources<CountriesDTOHolder>("/countries");

            //var type = typeof(TEntity);


            //var xd = type.Name + "s"; 

            //Type contextType = typeof(AppDbContext);

            //PropertyInfo propertyInfo = contextType.GetProperty(xd);

            //DbSet<typeof(M)> list = (DbSet<typeof(M)>)propertyInfo.GetValue(_context, null);


            //var countriesInBase = await _context.Countries.ToListAsync();
            //if (countriesInBase.Count != 0)
            //    return countriesInBase;

            //var container =
            //    await _client.DownloadAllIResources<CountriesDTOHolder>("/countries");

            //var countries = container.DTOsHolder.Countries;

            //_context.Countries.AddRange(countries);
            //await _context.SaveChangesAsync();

            return itemsInBase;
        }
    }
}
