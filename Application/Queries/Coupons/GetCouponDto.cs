using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Coupons
{
    class GetCouponDto
    {
        public int CouponId { get; init; }

        public int UserId { get; set; }

        public decimal Bid { get; init; }

        public decimal TotalCourse { get; init; }

        public List<GetCouponBetDto> Bets { get; init; }
    }

    class GetCouponBetDto
    {
        public int BetId { get; init; }

        public string BetValue { get; init; }
    }
}
