using Bookmaker.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.Models
{
    public class League
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public LeagueType Type { get; set; }

        private int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public string CountryCode { get; set; }

        public int Season { get; set; }

        public DateTime? SeasonStart { get; set; }

        public DateTime? SeasonEnd { get; set; }

        public string Logo { get; set; }

        public string Flag { get; set; }

        public bool HasStandings { get; set; }

        public bool IsCurrent { get; set; }

        public bool HasCoverageStandings { get; set; }

        public bool HasPlayers { get; set; }

        public bool HasTopScorers { get; set; }

        public bool HasPredictions { get; set; }

        public bool HasOdds { get; set; }

        public bool HasEvents { get; set; }

        public bool HasLineups { get; set; }

        public bool HasStatistics { get; set; }

        public bool HasPlayersStatistics { get; set; }

    }
}
