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
        public Bet Bet { get; set; }

        public string Value { get; set; }

        public decimal Odd { get; set; }
    }
}
