using System;
using System.Collections.Generic;
using System.Text;
using ApiFootball.Client;
using Domain.Data;

namespace ApiFootball.Seeders
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
