using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Models;
using Application.Queries.Coupons.Get;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Coupons.GetAll
{
    public class GetAllCouponsQueryHandler : BaseQueryHandler, IRequestHandler<GetAllCouponsQuery, Response>
    {
        public GetAllCouponsQueryHandler(IDbContext context, IMapper mapper, IUserContextService userCtx)
            : base(context, mapper, userCtx)
        {
        }

        public async Task<Response> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userContextService.GetUserId();

            var readCoupons = await _context.ReadCoupons
                .AsNoTracking()
                .Include(x => x.Items)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Id)
                .ToListAsync(cancellationToken);

            if (!readCoupons.Any())
                return Response.Failure(Errors.EntityNotFound<ReadCoupon>());

            var readCouponDtos = _mapper.Map<List<ReadCouponDto>>(readCoupons);

            return Result<List<ReadCouponDto>>.Create(readCouponDtos);
        }
    }
}
