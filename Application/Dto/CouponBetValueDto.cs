using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class CouponBetValueDto : IMapFrom<CouponBetValue>
    {
        public int CouponId { get; set; }

        public CouponDto Coupon { get; set; }

        public int BetValueId { get; set; }

        public BetValueDto BetValue { get; set; }
    }
}
