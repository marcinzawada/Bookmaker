using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities
{
    public class Fixture
    {
        [Key]
        public int Id { get; set; }

        public int ExtFixtureId { get; set; }

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public virtual League League { get; set; }

        public DateTime? EventDate { get; set; }

        public DateTime? FirstHalfStart { get; set; }

        public DateTime? SecondHalfStart { get; set; }

        public int? RoundId { get; set; }

        [ForeignKey("RoundId")]
        public virtual Round Round { get; set; }

        public MatchStatus Status { get; set; }

        [MaxLength(64)]
        public string StatusName { get; set; }

        public int? Elapsed { get; set; }

        [MaxLength(128)]
        public string Venue { get; set; }

        [MaxLength(128)]
        public string Referee { get; set; }

        public int HomeTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }

        public int? ScoreId { get; set; }

        [ForeignKey("ScoreId")]
        public Score Score { get; set; }

        public DateTime? UpdatedBetsAt { get; set; }

        public virtual List<Bet> Bets { get; set; } = new List<Bet>();

    }
}
