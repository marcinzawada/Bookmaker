using ApiFootball.Client;
using Infrastructure.Data;

namespace ApiFootball.Services
{
    public class ApiFootballBaseService
    {
        protected readonly AppDbContext _context;
        protected readonly IApiFootballClient _client;


        public ApiFootballBaseService(AppDbContext context, IApiFootballClient client)
        {
            _context = context;
            _client = client;
        }

    }
}
