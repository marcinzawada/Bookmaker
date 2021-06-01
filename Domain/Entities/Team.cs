using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Team
    {   
        [Key]
        public int Id { get; set; }

        public int ExtTeamId { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Code { get; set; }

        [MaxLength(256)]
        public string Logo { get; set; }

        public bool IsNational { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public int? CountryId { get; set; }

        public int? Founded { get; set; }

        [MaxLength(256)]
        public string VenueName { get; set; }

        [MaxLength(32)]
        public string VenueSurface { get; set; }

        [MaxLength(256)]
        public string VenueAddress { get; set; }

        [MaxLength(128)]
        public string VenueCity { get; set; }

        public int? VenueCapacity { get; set; }

        public virtual List<LeagueTeam> Leagues { get; set; } = new List<LeagueTeam>();

        public List<Fixture> HomeFixtures { get; set; } = new List<Fixture>();
        
        public List<Fixture> AwayFixtures { get; set; } = new List<Fixture>();
    }
}
