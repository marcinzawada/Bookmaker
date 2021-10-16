using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PotentialBet
    {
        [Key]
        public int Id { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public virtual League League { get; set; }

        public int FixtureId { get; set; }

        [ForeignKey("FixtureId")]
        public virtual Fixture Fixture { get; set; }

        public int BookieId { get; set; }

        [ForeignKey("BookieId")]
        public virtual Bookie Bookie { get; set; }

        public int LabelId { get; set; }

        [ForeignKey("LabelId")]
        public virtual Label Label { get; set; }

        public virtual ICollection<BetValue> BetValues { get; set; } = new List<BetValue>();
    }
}
