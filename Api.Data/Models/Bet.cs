using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Data.Models
{
    public class Bet
    {
        [Key]
        private int Id { get; set; }

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
