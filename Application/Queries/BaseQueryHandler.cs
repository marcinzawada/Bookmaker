using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;

namespace Application.Queries
{
    public abstract class BaseQueryHandler
    {
        protected readonly IDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
