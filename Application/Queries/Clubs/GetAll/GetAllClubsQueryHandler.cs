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
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Clubs.GetAll
{

    public class GetAllClubsQueryHandler : BaseQueryHandler, IRequestHandler<GetAllClubsQuery, Response>
    {
        public GetAllClubsQueryHandler(IDbContext context, IMapper mapper, IUserContextService userContextService) 
            : base(context, mapper, userContextService)
        {
        }

        public async Task<Response> Handle(GetAllClubsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContextService.GetUserId();

            var clubs = await _context.Clubs
                .Include(x => x.ClubUsers)
                .Where(x => x.ClubUsers.Any(y => y.UserId == userId))
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (!clubs.Any())
                return Response.Failure(Errors.EntityNotFound<Club>());

            var clubDtos = new List<ClubDto>();

            foreach (var club in clubs)
            {
                clubDtos.Add(new ClubDto
                {
                    Id = club.Id,
                    Name = club.Name,
                    NumberOfMembers = club.ClubUsers.Count
                });
            }

            return Result<List<ClubDto>>.Create(clubDtos);
        }
    }

}
