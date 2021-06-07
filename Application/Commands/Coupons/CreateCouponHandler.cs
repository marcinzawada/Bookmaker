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
                .Where(x => request.BetValueIds.Contains(x.Id))
                .ToListAsync(cancellationToken);

            if (betValues.Count != request.BetValueIds.Count)
                return Response.Failure(Errors.EntityNotFound<BetValue>());

            var coupon = new CouponBuilder()
                .SetUserId(_userContextService.GetUserId())
                .SetBetValues(betValues)
                .SetBid(request.Bid)
                .Build();

            await _context.Coupons.AddAsync(coupon, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return CreatedResponse.Create($"api/coupon/{coupon.Id}");
        }
    }
}
