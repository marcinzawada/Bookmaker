using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(8)]
        public string Code { get; set; }

        [MaxLength(256)]
        public string Flag { get; set; }

        public virtual List<League> Leagues { get; set; } = new List<League>();

        public virtual List<Team> Teams { get; set; } = new List<Team>();
    }
}
