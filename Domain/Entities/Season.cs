using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Season
    {
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        public virtual List<League> Leagues { get; set; } = new List<League>();
    }
}
