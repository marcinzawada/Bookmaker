using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Builders
{
    public class ReadCouponBuilder
    {
        private readonly ReadCoupon _readCoupon = new();

        public ReadCouponBuilder SetItems(IEnumerable<BetValue> betValues)
        {
            var readCouponItems = new List<ReadCouponItem>();
            var totalCourse = 1m;

            foreach (var betValue in betValues)
            {
                var matchWinnerOptionIsCorrect = Enum.TryParse(betValue.Value, true, out MatchWinnerOption matchWinnerOption);
                if (!matchWinnerOptionIsCorrect)
                    throw new Exception($"{betValue.Value} cannot be converted to MatchWinnerOption enum");

                if (betValue.Bet.Fixture.EventDate == null)
                    throw new Exception($"EventData for {betValue.Bet.Fixture.Id} is null");

                readCouponItems.Add(new ReadCouponItem
                {
                    HomeTeamName = betValue.Bet.Fixture.HomeTeam.Name,
                    AwayTeamName = betValue.Bet.Fixture.AwayTeam.Name,
                    LabelName = betValue.Bet.Label.Name,
                    Odd = betValue.Odd,
                    MatchWinnerOption = matchWinnerOption,
                    EventDate = (DateTime)betValue.Bet.Fixture.EventDate,
                });

                totalCourse *= betValue.Odd;
            }

            _readCoupon.Items = readCouponItems;
            _readCoupon.TotalCourse = totalCourse;

            return this;
        }

        public ReadCouponBuilder SetUserId(int userId)
        {
            _readCoupon.UserId = userId;
            return this;
        }

        public ReadCouponBuilder SetBid(decimal bid)
        {
            _readCoupon.Bid = Math.Round(bid, 2);
            return this;
        }

        public ReadCoupon Build()
        {
            _readCoupon.CreatedAt = DateTime.UtcNow;
            return _readCoupon;
        }
    }
}
