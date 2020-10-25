using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Data.Models
{
    public class CouponBetValue
    {
        public int CouponId { get; set; }

        [ForeignKey("CouponId")]
        public Coupon Coupon { get; set; }

        public int BetValueId { get; set; }

        [ForeignKey("BetValueId")]
        public BetValue BetValue { get; set; }
    }
}
