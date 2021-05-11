using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFootball.Client;
using Domain.Data;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class TeamsAfDataInitialization : BaseAfDataInitialization
    {
        private readonly ILogger<TeamsAfDataInitialization> _logger;

        public TeamsAfDataInitialization(ILogger<TeamsAfDataInitialization> logger,
            AppDbContext context, IApiFootballClient client) : base(context, client)
        {
            _logger = logger;
        }
    }
}
