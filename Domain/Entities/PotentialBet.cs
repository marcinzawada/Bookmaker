using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PotentialBet : IEquatable<PotentialBet>
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

        public bool Equals(PotentialBet other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return LeagueId == other.LeagueId && FixtureId == other.FixtureId && BookieId == other.BookieId && LabelId == other.LabelId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PotentialBet) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LeagueId, FixtureId, BookieId, LabelId);
        }
    }
}
