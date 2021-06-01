using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }

        public int OddId { get; set; }

        [ForeignKey("OddId")]
        public virtual Odd Odd { get; set; }

        public int BookieId { get; set; }

        [ForeignKey("BookieId")]
        public virtual Bookie Bookie { get; set; }

        public int LabelId { get; set; }

        [ForeignKey("LabelId")]
        public virtual Label Label { get; set; }

        public virtual List<BetValue> BetValues { get; set; } = new List<BetValue>();
    }
}
