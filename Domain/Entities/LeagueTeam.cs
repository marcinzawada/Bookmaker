using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class LeagueTeam
    {
        [Required]
        public int LeagueId { get; set; }

        [ForeignKey(nameof(LeagueId))]
        public virtual League League { get; set; }

        [Required]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
    }
}
