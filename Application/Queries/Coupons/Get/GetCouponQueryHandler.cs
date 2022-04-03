using System.Threading;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Models;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Coupons.Get
{

    public class GetCouponHandler : BaseQueryHandler, IRequestHandler<GetCouponQuery, Response>
    {
        public GetCouponHandler(IDbContext context, IMapper mapper, IUserContextService userCtx) 
            : base(context, mapper, userCtx)
        {
        }

        public async Task<Response> Handle(GetCouponQuery request, CancellationToken cancellationToken)
        {
            var readCoupon = await _context.ReadCoupons
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.CouponId == request.CouponId, cancellationToken);

            var readCouponDto = _mapper.Map<ReadCouponDto>(readCoupon);

            if (readCoupon == null)
                return Response.Failure(Errors.EntityNotFound<ReadCoupon>());

            return Result<ReadCouponDto>.Create(readCouponDto);
        }
    }

}
