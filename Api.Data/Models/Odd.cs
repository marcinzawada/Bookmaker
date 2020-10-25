using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Data.Models
{
    public class Odd
    {
        [Key]
        public int Id { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; }

        public int FixtureId { get; set; }

        [ForeignKey("FixtureId")]
        public Fixture Fixture { get; set; }

        public DateTime UpdateAt { get; set; }

        public List<Bet> Bets { get; set; }
    }
}
