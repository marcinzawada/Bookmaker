using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.Models
{
    public class Fixture
    {
        public int FixtureId { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]

        public League League { get; set; }

        public DateTime? EventDate { get; set; }

        public DateTime? EventTimestamp { get; set; }

        public DateTime? FirstHalfStart { get; set; }

        public DateTime? SecondHalfStart { get; set; }

        public string Round { get; set; }

        public string Status { get; set; }

        public string StatusShort { get; set; }

        public int Elapsed { get; set; }

        public string Venue { get; set; }

        public string Referee { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int GoalsHomeTeam { get; set; }

        public int GoalsAwayTeam { get; set; }

        public string HalftimeScore { get; set; }

        public string FulltimeScore { get; set; }

        public string ExtratimeScore { get; set; }

        public string PenaltyScore { get; set; }
    }
}
