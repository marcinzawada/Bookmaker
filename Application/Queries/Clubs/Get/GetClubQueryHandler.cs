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
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Clubs.Get
{

    public class GetClubQueryHandler : BaseQueryHandler, IRequestHandler<GetClubQuery, Response>
    {
        public GetClubQueryHandler(IDbContext context, IMapper mapper, IUserContextService userContextService) 
            : base(context, mapper, userContextService)
        {
        }

        public async Task<Response> Handle(GetClubQuery request, CancellationToken cancellationToken)
        {
            var club = await _context.Clubs
                .Include(x => x.ClubUsers)
                .ThenInclude(x => x.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.ClubId, cancellationToken);

            if (club == null)
                return Response.Failure(Errors.EntityNotFound<Club>());

            var clubDto = _mapper.Map<ClubDto>(club);
            clubDto.NumberOfMembers = club.ClubUsers.Count;

            var users = club.ClubUsers.Select(x => x.User).ToList();
            clubDto.Users = _mapper.Map<List<UserDto>>(users);

            return Result<ClubDto>.Create(clubDto);
        }
    }

}
