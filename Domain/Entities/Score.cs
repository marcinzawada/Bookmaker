using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Score
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
    }
}
