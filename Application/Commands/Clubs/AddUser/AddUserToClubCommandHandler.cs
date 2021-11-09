using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Clubs.Create;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Clubs.AddUser
{
    public class AddUserToClubCommandHandler : BaseCommandHandler, IRequestHandler<AddUserToClubCommand, Response>
    {
        public AddUserToClubCommandHandler(IDbContext context, IUserContextService userContextService) : base(context, userContextService)
        {
        }

        public async Task<Response> Handle(AddUserToClubCommand request, CancellationToken cancellationToken)
        {
            var club = await _context.Clubs
                .FirstOrDefaultAsync(x => x.Id == request.ClubId, cancellationToken);

            if (club == null)
                return Response.Failure(Errors.EntityNotFound<Club>());

            var userId = _userContextService.GetUserId();

            if (club.AdminId != userId)
                return Response.Failure(Errors.Forbidden());

            var newUser = await _context.Users.FirstOrDefaultAsync(x => 
                x.Email.Trim().ToLower() == request.UserEmail.Trim().ToLower(), cancellationToken);

            if (newUser == null)
                return Response.Failure(Errors.EntityNotFound<User>());

            if (newUser.Id == userId)
                return Response.Failure(Errors.InvalidUserToAddToClub);

            club.ClubUsers.Add(new ClubUser
            {
                UserId = newUser.Id
            });

            _context.Clubs.Update(club);
            await _context.SaveChangesAsync(cancellationToken);

            return Response.Success();
        }
    }

}

