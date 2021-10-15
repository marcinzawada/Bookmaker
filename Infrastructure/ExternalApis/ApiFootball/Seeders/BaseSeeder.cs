using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;

namespace Infrastructure.ExternalApis.ApiFootball.Seeders
{
    public class BaseSeeder
    {
        protected AppDbContext _context;
        protected IApiFootballClient _client;

        public BaseSeeder(AppDbContext context, IApiFootballClient client)
        {
            _context = context;
            _client = client;
        }
    }
}
