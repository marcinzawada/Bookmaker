using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class BetValue
    {
        [Key]
        public int Id { get; set; }

        public int BetId { get; set; }

        [ForeignKey("BetId")]
        public virtual PotentialBet Bet { get; set; }

        [MaxLength(64)]
        public string Value { get; set; }

        public decimal Odd { get; set; }
    }
}
