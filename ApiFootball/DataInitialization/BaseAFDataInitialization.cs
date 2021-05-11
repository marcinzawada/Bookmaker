using ApiFootball.Client;
using Infrastructure.Data;

namespace ApiFootball.DataInitialization
{
    public class BaseAfDataInitialization
    {
        protected readonly AppDbContext _context;
        protected readonly IApiFootballClient _client;

        public BaseAfDataInitialization(AppDbContext context, IApiFootballClient client)
        {
            _context = context;
            _client = client;
        }
    }
}
