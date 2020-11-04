using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Models;

namespace ApiFootball.BetTypes.ExactScoreType.Generators
{
    public class ExactScoreSecondHalfGenerator : BaseBetTypeGenerator<ExactScoreSecondHalf>
    {
        public new const int ApiLabelId = 62;
        public new const string Name = "Exact Score Second Half";


        public ExactScoreSecondHalfGenerator()
        {
        }

        public ExactScoreSecondHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 62;
        }

        protected override void InitializeBetType()
        {
            BetType = new ExactScoreSecondHalf();
        }
    }
}
