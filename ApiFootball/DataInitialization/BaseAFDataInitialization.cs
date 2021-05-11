﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFootball.Client;
using Domain.Data;

namespace Bookmaker.ApiFootball.DataInitialization
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