using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Clubs.Create
{
    public class CreateClubCommandHandler : BaseCommandHandler, IRequestHandler<CreateClubCommand, Response>
    {
        public CreateClubCommandHandler(IDbContext context, IUserContextService userContextService) : base(context, userContextService)
        {
        }

        public async Task<Response> Handle(CreateClubCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextService.GetUserId();

            var newClub = new Club
            {
                AdminId = userId,
                Name = request.ClubName,
                ClubUsers = new List<ClubUser>
                {
                    new()
                    {
                        UserId = userId
                    }
                }
            };

            await _context.Clubs.AddAsync(newClub, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return CreatedResponse.Create($"api/clubs/{newClub.Id}");
        }
    }

}

