using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApiFootball.Client;
using Domain.Data;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class DataInitialization : BaseAfDataInitialization, IDataInitialization
    {
        private readonly ILogger<DataInitialization> _logger;

        public DataInitialization(ILogger<DataInitialization> logger,
            AppDbContext context, IApiFootballClient client) : base(context, client)
        {
            _logger = logger;
        }


        public async Task<List<TEntity>> DownloadAllFirstTime<TDto,TEntity>() where TEntity : class
        {
            var itemsInBaseCount =  _context.Set<TEntity>().Count();
            if (itemsInBaseCount != 0)
                return new List<TEntity>();

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

            return new List<TEntity>();
        }
    }
}
