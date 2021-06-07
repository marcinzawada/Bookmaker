using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Builders
{
    public class CouponBuilder
    {
        private readonly Coupon _coupon = new();

        public CouponBuilder SetBetValues(IEnumerable<BetValue> betValues)
        {
            var couponBetValues = new List<CouponBetValue>();
            var totalCourse = 0m;

            foreach (var betValue in betValues)
            {
                couponBetValues.Add(new CouponBetValue
                {
                    BetValueId = betValue.Id
                });

                totalCourse *= betValue.Odd;
            }

            _coupon.CouponBetValues = couponBetValues;
            _coupon.TotalCourse = totalCourse;

            return this;
        }

        public CouponBuilder SetUserId(int userId)
        {
            _coupon.UserId = userId;
            return this;
        }

        public CouponBuilder SetBid(decimal bid)
        {
            _coupon.Bid = Math.Round(bid, 2);
            return this;
        }

        public Coupon Build() => _coupon;
    }
}
