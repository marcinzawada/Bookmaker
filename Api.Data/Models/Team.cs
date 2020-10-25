using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class Team
    {   
        [Key]
        public int Id { get; set; }

        public int ExtTeamId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Logo { get; set; }

        public bool IsNational { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public int CountryId { get; set; }

        public int Founded { get; set; }

        public string VenueName { get; set; }

        public string VenueSurface { get; set; }

        public string VenueAddress { get; set; }

        public string VenueCity { get; set; }

        public int VenueCapacity { get; set; }

        public int LeagueId { get; set; }

        public League League { get; set; }
    }
}
