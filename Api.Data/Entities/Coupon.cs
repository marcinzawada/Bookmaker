using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        public decimal Bid { get; set; }

        public List<CouponBetValue> CouponBetValues { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
