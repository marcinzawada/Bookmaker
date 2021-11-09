using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services;
using AutoMapper;

namespace Application.Queries
{
    public abstract class BaseQueryHandler
    {
        protected readonly IDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly IUserContextService _userContextService;


        protected BaseQueryHandler(IDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }
    }
}
