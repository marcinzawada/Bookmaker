using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Data.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        public decimal Bid { get; set; }

        public List<CouponBetValue> CouponBetValues { get; set; }
    }
}
