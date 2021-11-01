using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Score : IEquatable<Score>
    {
        [Key]
        public int Id { get; set; }

        public int FixtureId { get; set; }

        [ForeignKey("FixtureId")]
        public virtual Fixture Fixture { get; set; }

        public int? ExtFixtureId { get; set; }

        public int? GoalsHomeTeam { get; set; }

        public int? GoalsAwayTeam { get; set; }

        public int? HalftimeHomeGoals { get; set; }

        public int? HalftimeAwayGoals { get; set; }

        public int? FullTimeHomeGoals { get; set; }

        public int? FullTimeAwayGoals { get; set; }

        public int? ExtraTimeHomeGoals { get; set; }

        public int? ExtraTimeAwayGoals { get; set; }

        public int? PenaltyHomeGoals { get; set; }

        public int? PenaltyAwayGoals { get; set; }

        public int? WinnerId { get; set; } 

        [ForeignKey("WinnerId")]
        public virtual Team Winner { get; set; }

        public bool Equals(Score other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ExtFixtureId == other.ExtFixtureId && GoalsHomeTeam == other.GoalsHomeTeam && GoalsAwayTeam == other.GoalsAwayTeam && HalftimeHomeGoals == other.HalftimeHomeGoals && HalftimeAwayGoals == other.HalftimeAwayGoals && FullTimeHomeGoals == other.FullTimeHomeGoals && FullTimeAwayGoals == other.FullTimeAwayGoals && ExtraTimeHomeGoals == other.ExtraTimeHomeGoals && ExtraTimeAwayGoals == other.ExtraTimeAwayGoals && PenaltyHomeGoals == other.PenaltyHomeGoals && PenaltyAwayGoals == other.PenaltyAwayGoals;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Score) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(ExtFixtureId);
            hashCode.Add(GoalsHomeTeam);
            hashCode.Add(GoalsAwayTeam);
            hashCode.Add(HalftimeHomeGoals);
            hashCode.Add(HalftimeAwayGoals);
            hashCode.Add(FullTimeHomeGoals);
            hashCode.Add(FullTimeAwayGoals);
            hashCode.Add(ExtraTimeHomeGoals);
            hashCode.Add(ExtraTimeAwayGoals);
            hashCode.Add(PenaltyHomeGoals);
            hashCode.Add(PenaltyAwayGoals);
            return hashCode.ToHashCode();
        }
    }
}
