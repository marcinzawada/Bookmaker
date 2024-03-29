﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Bid { get; set; }

        public virtual List<CouponBetValue> CouponBetValues { get; set; } = new();

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCourse { get; set; }

        public bool IsCompleted { get; set; } = false;

        public int ReadCouponId { get; set; }

        [ForeignKey(nameof(ReadCouponId))]
        public ReadCoupon ReadCoupon { get; set; }

        public bool? IsCouponWinning { get; set; }
    }
}
