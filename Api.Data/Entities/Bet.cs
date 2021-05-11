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
        public Odd Odd { get; set; }

        public int BookieId { get; set; }

        [ForeignKey("BookieId")]
        public Bookie Bookie { get; set; }

        public int LabelId { get; set; }

        [ForeignKey("LabelId")]
        public Label Label { get; set; }

        public List<BetValue> BetValues { get; set; }
    }
}
