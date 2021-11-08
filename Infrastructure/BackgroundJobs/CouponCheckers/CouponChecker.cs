using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.BackgroundJobs.CouponCheckers.BetTypesCheckers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.BackgroundJobs.CouponCheckers
{
    public class CouponChecker
    {
        private readonly AppDbContext _context;
        private readonly BetTypeCheckerFactory _betTypeCheckerFactory;
        public CouponChecker(AppDbContext context, BetTypeCheckerFactory betTypeCheckerFactory)
        {
            _context = context;
            _betTypeCheckerFactory = betTypeCheckerFactory;
        }

        public async Task Check()
        {
            var coupons = await FetchCoupons();

            foreach (var coupon in coupons)
            {
                var readCoupon = await FetchReadCoupon(coupon);

                var couponBetValuesNumber = coupon.CouponBetValues.Count;

                var unresolvedCouponBetValues = SelectUnresolvedCouponBetValues(coupon);

                if (unresolvedCouponBetValues.Count == 0)
                    coupon.IsCompleted = true;

                var isUnfinishedMatch = false;

                foreach (var unresolvedCouponBetValue in unresolvedCouponBetValues)
                {
                    var betValue = unresolvedCouponBetValue.BetValue;
                    var bet = betValue.Bet;
                    var label = await FetchLabel(bet);

                    var checker = _betTypeCheckerFactory.CreateBetChecker(label, _context);

                    var isMatchAlreadyFinished = await checker.CheckIsMatchAlreadyFinished(betValue);

                    if (!isMatchAlreadyFinished)
                    {
                        isUnfinishedMatch = true;
                        continue;
                    }

                    var isBetWinning = await checker.Check(betValue);
                    if (!isBetWinning)
                        coupon.IsCouponWinning = false;

                    unresolvedCouponBetValue.IsBetWinning = isBetWinning;

                    await UpdateReadCouponItem(bet, readCoupon, label, betValue, isBetWinning);
                }

                _context.CouponBetValues.UpdateRange(unresolvedCouponBetValues);

                SetCompletedAndWinningInCoupon(isUnfinishedMatch, couponBetValuesNumber, unresolvedCouponBetValues, coupon);
                _context.Coupons.Update(coupon);

                SetCompletedAndWinningInReadCoupon(readCoupon, coupon);
                readCoupon.UpdatedAt = DateTime.UtcNow;
                _context.ReadCoupons.Update(readCoupon);

                await _context.SaveChangesAsync();
            }
        }

        private async Task<List<Coupon>> FetchCoupons()
        {
            var coupons = await _context.Coupons
                .Where(x => !x.IsCompleted)
                .Include(x => x.CouponBetValues)
                .ThenInclude(x => x.BetValue)
                .ThenInclude(x => x.Bet)
                .ThenInclude(x => x.Fixture)
                .ThenInclude(x => x.Score)
                .ToListAsync();
            return coupons;
        }

        private async Task<ReadCoupon> FetchReadCoupon(Coupon coupon)
        {
            var readCoupon = await _context.ReadCoupons
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.CouponId == coupon.Id);
            return readCoupon;
        }

        private static List<CouponBetValue> SelectUnresolvedCouponBetValues(Coupon coupon)
        {
            var unresolvedCouponBetValues = coupon.CouponBetValues
                .Where(x => x.IsBetWinning == null).ToList();
            return unresolvedCouponBetValues;
        }


        private async Task<Label> FetchLabel(PotentialBet bet)
        {
            var label = await _context.Labels
                .FirstOrDefaultAsync(x => x.Id == bet.LabelId);
            return label;
        }

        private async Task UpdateReadCouponItem(PotentialBet bet, ReadCoupon readCoupon, Label label, BetValue betValue,
            bool isBetWinning)
        {
            var fixture = await FetchFixture(bet);

            var readCouponItem = FetchReadCouponItem(readCoupon, label, fixture, betValue);

            if (readCouponItem != null)
            {
                readCouponItem.IsBetWinning = isBetWinning;
                SetGoalsInReadCouponItem(fixture, readCouponItem);
            }
        }

        private async Task<Fixture> FetchFixture(PotentialBet bet)
        {
            var fixture = await _context.Fixtures
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .FirstOrDefaultAsync(x => x.Id == bet.FixtureId);
            return fixture;
        }

        private static ReadCouponItem FetchReadCouponItem(ReadCoupon readCoupon, Label label, Fixture fixture,
            BetValue betValue)
        {
            var readCouponItem = readCoupon.Items
                .SingleOrDefault(x =>
                    x.LabelName == label.Name
                    && Equals(x.EventDate, fixture.EventDate)
                    && x.HomeTeamName == fixture.HomeTeam.Name
                    && x.AwayTeamName == fixture.AwayTeam.Name
                    && betValue.Value.Equals(x.MatchWinnerOption.ToString(), StringComparison.OrdinalIgnoreCase));
            return readCouponItem;
        }

        private static void SetGoalsInReadCouponItem(Fixture fixture, ReadCouponItem readCouponItem)
        {
            var score = fixture.Score;

            readCouponItem.HomeTeamGoals = score.GoalsHomeTeam;
            readCouponItem.AwayTeamGoals = score.GoalsAwayTeam;
            readCouponItem.HomeTeamGoalsExtraTime = score.ExtraTimeHomeGoals;
            readCouponItem.AwayTeamGoalsExtraTime = score.ExtraTimeAwayGoals;
            readCouponItem.HomeTeamGoalsPenalty = score.PenaltyHomeGoals;
            readCouponItem.AwayTeamGoalsPenalty = score.PenaltyHomeGoals;
        }

        private static void SetCompletedAndWinningInCoupon(bool isUnfinishedMatch, int couponBetValuesNumber,
            List<CouponBetValue> unresolvedCouponBetValues, Coupon coupon)
        {
            if (!isUnfinishedMatch && couponBetValuesNumber == unresolvedCouponBetValues.Count(x => x.IsBetWinning != null))
            {
                coupon.IsCompleted = true;
                coupon.IsCouponWinning ??= true;
            }
        }

        private static void SetCompletedAndWinningInReadCoupon(ReadCoupon readCoupon, Coupon coupon)
        {
            readCoupon.IsCouponWinning = coupon.IsCouponWinning;
            readCoupon.IsCompleted = coupon.IsCompleted;
        }
    }
}
