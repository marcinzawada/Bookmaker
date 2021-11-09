using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Models;
using Application.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Leaderboard
{

    public class GetLeaderboardQueryHandler : BaseQueryHandler, IRequestHandler<GetLeaderboardQuery, Response>
    {
        public GetLeaderboardQueryHandler(IDbContext context, IMapper mapper, IUserContextService userContextService) 
            : base(context, mapper, userContextService)
        {
        }

        public async Task<Response> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .OrderByDescending(x => x.GameTokens)
                .AsNoTracking()
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Result<List<UserDto>>.Create(users);
        }
    }

}
