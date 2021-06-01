using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class FixtureOdd
    {
        [Key]
        public int Id { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; }

        public int FixtureId { get; set; }

        [ForeignKey("FixtureId")]
        public Fixture Fixture { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Bet> Bets { get; set; }
    }
}
