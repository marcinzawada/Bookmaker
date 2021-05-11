using ApiFootball.Client;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace ApiFootball.DataInitialization
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
