﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Club
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        public int AdminId { get; set; }

        [ForeignKey(nameof(AdminId))]
        public virtual User Admin { get; set; }

        public virtual List<ClubUser> ClubUsers { get; set; } = new();
    }
}
