using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public interface IDataInitialization
    {
        public Task<List<TEntity>> DownloadAllFirstTime<DTO,TEntity>() where TEntity : class;
    }
}
