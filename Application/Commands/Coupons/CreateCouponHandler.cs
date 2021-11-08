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
            var betValues = await FetchBetValues(request, cancellationToken);

            if (betValues.Count != request.BetValueIds.Count)
                return Response.Failure(Errors.EntityNotFound<BetValue>());

            if (betValues.Select(x => x.BetId).Distinct().Count() != betValues.Count)
                return Response.Failure(Errors.InvalidBetData);

            var userId = _userContextService.GetUserId();

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

            if (user == null)
                throw new Exception($"User with id {userId} doesn't exist in base");

            if (request.Bid > user.GameTokens)
                return Response.Failure(Errors.InvalidBetData);

            UpdateUser(request, user);

            var coupon = CreateCoupon(request, betValues);

            var readCoupon = CreateReadCoupon(request, betValues);

            await SaveCouponAndReadCoupon(cancellationToken, coupon, readCoupon);

            await UpdateReadCouponIdInCoupon(cancellationToken, coupon, readCoupon);

            return CreatedResponse.Create($"api/coupon/{coupon.Id}");
        }

        private async Task<List<BetValue>> FetchBetValues(CreateCouponCommand request, CancellationToken cancellationToken)
        {
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
            return betValues;
        }

        private void UpdateUser(CreateCouponCommand request, User user)
        {
            user.GameTokens -= request.Bid;
            _context.Users.Update(user);
        }

        private Coupon CreateCoupon(CreateCouponCommand request, List<BetValue> betValues)
        {
            var coupon = new CouponBuilder()
                .SetUserId(_userContextService.GetUserId())
                .SetBetValues(betValues)
                .SetBid(request.Bid)
                .Build();
            return coupon;
        }

        private ReadCoupon CreateReadCoupon(CreateCouponCommand request, List<BetValue> betValues)
        {
            var readCoupon = new ReadCouponBuilder()
                .SetUserId(_userContextService.GetUserId())
                .SetItems(betValues)
                .SetBid(request.Bid)
                .Build();
            return readCoupon;
        }

        private async Task SaveCouponAndReadCoupon(CancellationToken cancellationToken, Coupon coupon, ReadCoupon readCoupon)
        {
            coupon.ReadCoupon = readCoupon;
            await _context.Coupons.AddAsync(coupon, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task UpdateReadCouponIdInCoupon(CancellationToken cancellationToken, Coupon coupon, ReadCoupon readCoupon)
        {
            coupon.ReadCouponId = readCoupon.Id;
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
