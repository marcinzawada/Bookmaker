using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class BetValue : IEquatable<BetValue>
    {
        [Key]
        public int Id { get; set; }

        public int BetId { get; set; }

        [ForeignKey("BetId")]
        public virtual PotentialBet Bet { get; set; }

        [MaxLength(64)]
        public string Value { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Odd { get; set; }

        public DateTime AddedAt { get; set; }

        public bool Equals(BetValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value && Odd == other.Odd;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BetValue) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Odd);
        }
    }
}
