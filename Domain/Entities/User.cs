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

        public virtual List<Coupon> Coupons { get; set; } = new List<Coupon>();

        public virtual List<RoomUser> RoomUsers { get; set; } = new List<RoomUser>();
        
        public virtual List<Room> ManagedRooms { get; set; } = new List<Room>();
    }
}
