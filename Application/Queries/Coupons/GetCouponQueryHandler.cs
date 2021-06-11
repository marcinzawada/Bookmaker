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
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Coupons
{

    public class GetCouponHandler : BaseQueryHandler, IRequestHandler<GetCouponQuery, Response>
    {
        public GetCouponHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Response> Handle(GetCouponQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons
                .AsNoTracking()
                .Include(x => x.CouponBetValues)
                .ThenInclude(x => x.BetValue.Bet)
                .ThenInclude(x => x.Label)
                .Include(x => x.CouponBetValues)
                .ThenInclude(x => x.BetValue.Bet.Odd.League)
                .Include(x => x.CouponBetValues)
                .ThenInclude(x => x.BetValue.Bet.Odd.Fixture.AwayTeam)
                .Include(x => x.CouponBetValues)
                .ThenInclude(x => x.BetValue.Bet.Odd.Fixture.HomeTeam)
                .Where(x => x.Id == request.CouponId)
                .ProjectTo<CouponDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
           
            //var query =
            //    "SELECT " +
            //    "C.Id AS CouponId, C.Bid, C.UserId, C.TotalCourse," +
            //    "B.Id AS BetId, BV.Value as BetValue," +
            //    "L.Id AS LeagueId, L.Name AS LeagueName," +
            //    "F.Id AS FixtureId," +
            //    "LB.Name AS LabelName," +
            //    "HT.Id AS HomeTeamId, HT.Name AS HomeTeamName," +
            //    "AT.Id AS AwayTeamId, AT.Name AS AwayTeamName " +
            //    "FROM Coupons AS C " +
            //    "JOIN CouponBetValues AS CBV ON C.Id = CBV.CouponId " +
            //    "JOIN BetValues AS BV ON BV.Id = CBV.BetValueId " +
            //    "JOIN Bets AS B ON B.Id = BV.BetId " +
            //    "JOIN Labels AS LB ON B.LabelId = LB.Id " +
            //    "JOIN Odds AS O ON B.OddId = O.Id " +
            //    "JOIN Leagues AS L ON O.LeagueId = L.Id " +
            //    "JOIN Fixtures AS F ON O.FixtureId = F.Id " +
            //    "JOIN Teams AS HT ON F.HomeTeamId = HT.Id " +
            //    "JOIN Teams AS AT ON F.AwayTeamId = AT.Id " +
            //    $"WHERE C.Id = {request.CouponId}";


            if (coupon is null)
                return Response.Failure(Errors.EntityNotFound<Coupon>());

            return Result<CouponDto>.Create(coupon);
        }
    }

}
