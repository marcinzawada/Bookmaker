using Bookmaker.Api.Data.Data.Enums;
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

        public MatchStatus Status { get; set; }

        public int? Elapsed { get; set; }

        public string Venue { get; set; }

        public string Referee { get; set; }

        [ForeignKey("HomeTeamId")]
        public Team HomeTeam { get; set; }

        public int HomeTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public Team AwayTeam { get; set; }

        public int AwayTeamId { get; set; }

        public int ScoreId { get; set; }

        [ForeignKey("ScoreId")]
        public Score Score { get; set; }
    }
}
