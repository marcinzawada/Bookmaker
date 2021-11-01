using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities
{
    public class Fixture : IEquatable<Fixture>
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

        public virtual List<PotentialBet> Bets { get; set; } = new();

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


        public bool Equals(Fixture other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ExtFixtureId == other.ExtFixtureId && LeagueId == other.LeagueId && Nullable.Equals(EventDate, other.EventDate) && Nullable.Equals(FirstHalfStart, other.FirstHalfStart) && Nullable.Equals(SecondHalfStart, other.SecondHalfStart) && RoundId == other.RoundId && Status == other.Status && StatusName == other.StatusName && Elapsed == other.Elapsed && HomeTeamId == other.HomeTeamId && AwayTeamId == other.AwayTeamId && Equals(Score, other.Score) && Nullable.Equals(UpdatedBetsAt, other.UpdatedBetsAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fixture) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(ExtFixtureId);
            hashCode.Add(LeagueId);
            hashCode.Add(EventDate);
            hashCode.Add(FirstHalfStart);
            hashCode.Add(SecondHalfStart);
            hashCode.Add(RoundId);
            hashCode.Add((int) Status);
            hashCode.Add(StatusName);
            hashCode.Add(Elapsed);
            hashCode.Add(HomeTeamId);
            hashCode.Add(AwayTeamId);
            hashCode.Add(Score);
            hashCode.Add(UpdatedBetsAt);
            return hashCode.ToHashCode();
        }
    }
}
