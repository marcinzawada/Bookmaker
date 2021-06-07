using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Dto;
using Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Odds.GetOdds
{
    public class GetOddsQueryHandler : BaseQueryHandler, IRequestHandler<GetOddsQuery, Response>
    {
        public GetOddsQueryHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Response> Handle(GetOddsQuery request, CancellationToken cancellationToken)
        {
            var oddDtos = await _context.Odds
                .AsNoTracking()
                .Where(x => x.LeagueId == request.LeagueId)
                .ProjectTo<OddDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (! oddDtos.Any())
                return Response.Failure(Errors.EntityNotFound<Odd>());

            return Result<List<OddDto>>.Create(oddDtos);
        }
    }
}
