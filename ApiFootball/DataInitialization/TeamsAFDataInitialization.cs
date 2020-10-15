using Bookmaker.Api.Data.Data;
using Bookmaker.ApiFootball.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class TeamsAFDataInitialization : BaseAFDataInitialization
    {
        private readonly ILogger<TeamsAFDataInitialization> _logger;

        public TeamsAFDataInitialization(ILogger<TeamsAFDataInitialization> logger,
            AppDbContext context, IApiFootballClient client) : base(context, client)
        {
            _logger = logger;
        }
    }
}
