using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace Api.Data.Models
{
    public class Round
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; }
    }
}
