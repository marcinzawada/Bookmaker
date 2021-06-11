using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Entities;

namespace Application.Common.Mappings.Mappers
{
    public class CouponToReadCouponMapper
    {
        public ReadCoupon Map(Coupon coupon)
        {
            var readCoupon = new ReadCoupon {CouponId = coupon.Id};

            var content = new ReadCouponDto
            {
                Id = coupon.Id,
                Bid = coupon.Bid,
                TotalCourse = coupon.TotalCourse,
            };

            foreach (var couponBetValue in coupon.CouponBetValues)
            {
                var betValue = couponBetValue.BetValue;
                var bet = betValue.Bet;
                var odd = bet.Odd;

                content.Bets.Add(new ReadCouponBetDto
                {
                    BetId = bet.Id,
                    BetValueId = betValue.Id,
                    OddId = odd.Id,
                    Odd = betValue.Odd,
                    OddValue = betValue.Value,
                    LabelId = betValue.Bet.LabelId,
                    LabelName = betValue.Bet.Label.Name,
                    RoundId = betValue.Bet.Odd.Fixture.RoundId,
                    RoundName = betValue.Bet.Odd.Fixture.Round.Name,
                    LeagueId = betValue.Bet.Odd.LeagueId,
                    LeagueName = betValue.Bet.Odd.League.Name,
                    FixtureId = betValue.Bet.Odd.FixtureId,
                    HomeTeam = new ReadCouponFixtureDto
                    {
                        TeamId = betValue.Bet.Odd.Fixture.HomeTeamId,
                        TeamName = betValue.Bet.Odd.Fixture.HomeTeam.Name,
                        TeamCode = betValue.Bet.Odd.Fixture.HomeTeam.Code
                    },
                    AwayTeam = new ReadCouponFixtureDto
                    {
                        TeamId = betValue.Bet.Odd.Fixture.AwayTeamId,
                        TeamName = betValue.Bet.Odd.Fixture.AwayTeam.Name,
                        TeamCode = betValue.Bet.Odd.Fixture.AwayTeam.Code
                    },
                });
            }

            return readCoupon;
        }
    }
}
