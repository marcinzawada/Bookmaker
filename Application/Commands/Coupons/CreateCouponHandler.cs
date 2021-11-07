using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Builders;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Coupons
{

    public class CreateCouponCommandHandler : BaseCommandHandler, IRequestHandler<CreateCouponCommand, Response>
    {
        public CreateCouponCommandHandler(IDbContext context, IUserContextService userContextService) : base(context, userContextService)
        {
        }

        public async Task<Response> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var user = _userContextService.User;
            var userId = _userContextService.GetUserId();
            
            var betValues = await _context.BetValues
                .AsNoTracking()
                .Include(x => x.Bet)
                .ThenInclude(x => x.Fixture)
                .ThenInclude(x => x.AwayTeam)
                .Include(x => x.Bet)
                .ThenInclude(x => x.Fixture)
                .ThenInclude(x => x.HomeTeam)
                .Include(x => x.Bet)
                .ThenInclude(x => x.Label)
                .Where(x => request.BetValueIds.Contains(x.Id))
                .ToListAsync(cancellationToken);

            if (betValues.Count != request.BetValueIds.Count)
                return Response.Failure(Errors.EntityNotFound<BetValue>());

            if (betValues.Select(x => x.BetId).Distinct().Count() != betValues.Count)
                return Response.Failure(Errors.InvalidBetData);

            var userFromBase = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

            if (userFromBase == null)
                throw new Exception($"User with id {userId} doesn't exist in base");

            if (request.Bid > userFromBase.GameTokens)
                return Response.Failure(Errors.InvalidBetData);

            userFromBase.GameTokens -= request.Bid;

            var coupon = new CouponBuilder()
                .SetUserId(_userContextService.GetUserId())
                .SetBetValues(betValues)
                .SetBid(request.Bid)
                .Build();

            var readCoupon = new ReadCoupon();
            var readCouponItems = new List<ReadCouponItem>();

            foreach (var betValue in betValues)
            {
                var matchWinnerOptionIsCorrect = Enum.TryParse(betValue.Value, out MatchWinnerOption matchWinnerOption);
                if (matchWinnerOptionIsCorrect)
                    throw new Exception($"{betValue.Value} cannot be converted to MatchWinnerOption enum");

                if(betValue.Bet.Fixture.EventDate == null)
                    throw new Exception($"EventData for {betValue.Bet.Fixture.Id} is null");

                readCouponItems.Add(new ReadCouponItem
                {
                    HomeTeamName = betValue.Bet.Fixture.HomeTeam.Name,
                    AwayTeamName = betValue.Bet.Fixture.AwayTeam.Name,
                    LabelName = betValue.Bet.Label.Name,
                    Odd = betValue.Odd,
                    MatchWinnerOption = matchWinnerOption,
                    EventDate = (DateTime) betValue.Bet.Fixture.EventDate,
                });

            }

            readCoupon.Items = readCouponItems;
            readCoupon.Bid = coupon.Bid;

            coupon.ReadCoupon = readCoupon;

            await _context.Coupons.AddAsync(coupon, cancellationToken);
            _context.Users.Update(userFromBase);

            await _context.SaveChangesAsync(cancellationToken);

            return CreatedResponse.Create($"api/coupon/{coupon.Id}");
        }
    }
}
