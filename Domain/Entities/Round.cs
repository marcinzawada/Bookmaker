using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Round
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; }
    }
}
