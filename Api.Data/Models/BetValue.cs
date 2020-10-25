using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Data.Models
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
