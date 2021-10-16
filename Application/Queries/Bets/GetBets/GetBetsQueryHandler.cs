using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Bets.GetBets
{
    public class GetBetsQueryHandler : BaseQueryHandler, IRequestHandler<GetBetsQuery, Response>
    {
        public GetBetsQueryHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Response> Handle(GetBetsQuery request, CancellationToken cancellationToken)
        {
            var betDtos = await _context.PotentialBets
                .AsNoTracking()
                .Include(x => x.BetValues)
                .Include(x => x.Label)
                .Where(x => x.LeagueId == request.LeagueId && x.BookieId == 7)
                .ProjectTo<BetDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (!betDtos.Any())
                return Response.Failure(Errors.EntityNotFound<PotentialBet>());

            return Result<List<BetDto>>.Create(betDtos);
        }
    }
}
