using Api.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Enums;

namespace Api.Data.Models
{
    public class Fixture
    {
        [Key]
        public int Id { get; set; }

        public int ExtFixtureId { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public League League { get; set; }

        public DateTime? EventDate { get; set; }

        public DateTime? FirstHalfStart { get; set; }

        public DateTime? SecondHalfStart { get; set; }

        public int? RoundId { get; set; }

        [ForeignKey("RoundId")]
        public Round Round { get; set; }

        public MatchStatus Status { get; set; }

        public string StatusName { get; set; }

        public int? Elapsed { get; set; }

        public string Venue { get; set; }

        public string Referee { get; set; }

        public int HomeTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public Team AwayTeam { get; set; }

        public int? ScoreId { get; set; }

        [ForeignKey("ScoreId")]
        public Score Score { get; set; }

        public List<Odd> Odds { get; set; }
    }
}
