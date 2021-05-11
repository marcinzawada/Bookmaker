using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        public decimal Bid { get; set; }

        public List<CouponBetValue> CouponBetValues { get; set; }
    }
}
