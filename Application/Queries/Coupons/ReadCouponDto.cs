using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;
using Domain.Enums;

namespace Application.Queries.Coupons
{
    public class ReadCouponDto : IMapFrom<ReadCoupon>
    {
        public int Id { get; set; }

        public int CouponId { get; set; }

        public decimal Bid { get; set; }

        public List<ReadCouponItemDto> Items { get; set; }

        public decimal TotalCourse { get; set; }

        public bool? IsCouponWinning { get; set; }

    }

    public class ReadCouponItemDto : IMapFrom<ReadCouponItem>
    {
        public int Id { get; set; }

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

        public bool IsBetWinning { get; set; }
    }
}
