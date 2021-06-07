using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Services;

namespace Application.Commands
{
    public abstract class BaseCommandHandler
    {
        protected readonly IDbContext _context;
        protected readonly IUserContextService _userContextService;

        protected BaseCommandHandler(IDbContext context, IUserContextService userContextService)
        {
            _context = context;
            _userContextService = userContextService;
        }
    }
}
