using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Clubs.Leave
{

    public class LeaveClubCommandHandler : BaseCommandHandler, IRequestHandler<LeaveClubCommand, Response>
    {
        public LeaveClubCommandHandler(IDbContext context, IUserContextService userContextService)
            : base(context, userContextService)
        {
        }

        public async Task<Response> Handle(LeaveClubCommand request, CancellationToken cancellationToken)
        {
            var club = await _context.Clubs
                .Include(x => x.ClubUsers)
                .FirstOrDefaultAsync(x => x.Id == request.ClubId, cancellationToken);

            if (club == null)
                return Response.Failure(Errors.EntityNotFound<Club>());

            var userId = _userContextService.GetUserId();
            var isAdmin = userId == club.AdminId;

            if (isAdmin)
                _context.Clubs.Remove(club);
            else
            {
                var clubUser = club.ClubUsers.FirstOrDefault(x => x.UserId == userId);

                if (clubUser == null)
                    return Response.Failure(Errors.Forbidden());

                _context.ClubUsers.Remove(clubUser);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Response.Success();
        }
    }

}
