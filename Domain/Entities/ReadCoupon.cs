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

        public decimal Bid { get; set; }

        public bool? IsCouponWinning { get; set; }

        public bool IsCompleted { get; set; } = false;

        public List<ReadCouponItem> Items { get; set; } = new();

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int UserId { get; set; }

        public decimal TotalCourse { get; set; }
    }
}
