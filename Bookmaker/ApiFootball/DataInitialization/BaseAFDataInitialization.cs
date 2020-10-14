using Bookmaker.ApiFootball.Client;
using Bookmaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class BaseAFDataInitialization
    {
        protected readonly AppDbContext _context;
        protected readonly IApiFootballClient _client;

        public BaseAFDataInitialization(AppDbContext context, IApiFootballClient client)
        {
            _context = context;
            _client = client;
        }
    }
}
