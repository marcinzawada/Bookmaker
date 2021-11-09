using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(512)]
        public string PasswordHash { get; set; }

        public decimal GameTokens { get; set; } = 400;

        public DateTime TimeOfLastTokensReceived { get; set; }

        public virtual List<Coupon> Coupons { get; set; } = new();

        public virtual List<ClubUser> ClubUser { get; set; } = new();
        
        public virtual List<Club> ManagedClubs { get; set; } = new();

        public virtual List<ReadCoupon> ReadCoupons { get; set; } = new();
    }
}
