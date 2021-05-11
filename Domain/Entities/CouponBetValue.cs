using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
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
