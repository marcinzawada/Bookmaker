using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;

namespace Application.Dto
{
    public class ReadCouponDto
    {
        public int Id { get; set; }

        public decimal Bid { get; set; }

        public decimal TotalCourse { get; set; }

        public List<ReadCouponBetDto> Bets { get; set; } = new List<ReadCouponBetDto>();
    }

    public class ReadCouponBetDto
    {
        public int BetId { get; set; }

        public int BetValueId { get; set; }

        public int OddId { get; set; }

        public decimal Odd { get; set; }

        public string OddValue { get; set; }

        public int LabelId { get; set; }

        public string LabelName { get; set; }

        public int? RoundId { get; set; }

        public string RoundName { get; set; }

        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public int FixtureId { get; set; }

        public ReadCouponFixtureDto HomeTeam { get; set; }

        public ReadCouponFixtureDto AwayTeam { get; set; }

    }

    public record ReadCouponFixtureDto
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string TeamCode { get; set; }
    }

}
