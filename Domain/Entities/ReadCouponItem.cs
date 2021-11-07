using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class ReadCouponItem
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ReadCouponId))]
        public virtual ReadCoupon ReadCoupon { get; set; }

        public int ReadCouponId { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public int? HomeTeamGoals { get; set; }

        public int? AwayTeamGoals { get; set; }

        public int? HomeTeamGoalsExtraTime { get; set; }

        public int? AwayTeamGoalsExtraTime { get; set; }

        public int? HomeTeamGoalsPenalty { get; set; }

        public int? AwayTeamGoalsPenalty { get; set; }

        public MatchWinnerOption MatchWinnerOption { get; set; }

        public decimal Odd { get; set; }

        public DateTime EventDate { get; set; }

        public string LabelName { get; set; }
    }
}
