using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReadCoupon
    {
        [Key]
        public int Id { get; set; }

        public int CouponId { get; set; }

        [ForeignKey(nameof(CouponId))]
        public Coupon Coupon { get; set; }

        public string Content { get; set; }
    }
}
