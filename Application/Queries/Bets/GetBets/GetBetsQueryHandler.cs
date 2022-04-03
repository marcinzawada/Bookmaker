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
using Application.Services;
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
        public GetBetsQueryHandler(IDbContext context, IMapper mapper, IUserContextService userCtx) 
            : base(context, mapper, userCtx)
        {
        }

        public async Task<Response> Handle(GetBetsQuery request, CancellationToken cancellationToken)
        {
            var betDtos = await _context.PotentialBets
                .AsNoTracking()
                .Include(x => x.BetValues)
                .Include(x => x.Label)
                .Include(x => x.Fixture)
                .Include(x => x.League)
                .ThenInclude(x => x.Country)
                .OrderBy(x => x.Fixture.EventDate)
                .Where(x => x.LeagueId == request.LeagueId && x.BookieId == 7)
                .ProjectTo<BetDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (!betDtos.Any())
                return Response.Failure(Errors.EntityNotFound<PotentialBet>());

            foreach (var betDto in betDtos)
            {
                betDto.BetValues = betDto
                    .BetValues
                    .OrderByDescending(x => x.AddedAt)
                    .GroupBy(x => new { x.Bet, x.Value })
                    .Select(x => x.First())
                    .ToList();
            }

            return Result<List<BetDto>>.Create(betDtos);
        }
    }
}
