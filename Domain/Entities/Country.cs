using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Flag { get; set; }

        public List<League> Leagues { get; set; }

        public List<Team> Teams { get; set; }
    }
}
