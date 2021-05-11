﻿using Bookmaker.Api.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFootball.Client;

namespace Bookmaker.ApiFootball.Services
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
