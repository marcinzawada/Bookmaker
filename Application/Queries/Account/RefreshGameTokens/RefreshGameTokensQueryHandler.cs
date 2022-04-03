using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Application.Common.Interfaces;
using Application.Models;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Account.RefreshTokens
{

    public class AddTokensCommandHandler : BaseCommandHandler, IRequestHandler<AddTokensCommand, Response>
    {
        public AddTokensCommandHandler(IDbContext context, IUserContextService userContextService) : base(context, userContextService)
        {
        }

        public async Task<Response> Handle(AddTokensCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContextService.GetUserId();

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

            if (user == null)
                throw new Exception($"User with id: {userId} doesn't exist in base");

            var hasPassed24Hours = user.TimeOfLastTokensReceived.AddHours(24) < DateTime.UtcNow;

            if (hasPassed24Hours)
            {
                user.GameTokens += 100;
                user.TimeOfLastTokensReceived = DateTime.UtcNow;
                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Result<decimal>.Create(user.GameTokens);
        }
    }

}
