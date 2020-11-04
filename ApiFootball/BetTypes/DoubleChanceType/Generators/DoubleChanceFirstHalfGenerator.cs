using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Models;
using ApiFootball.BetTypes.ExactScoreType;

namespace ApiFootball.BetTypes.DoubleChanceType.Generators
{
    public class DoubleChanceFirstHalfGenerator : BaseBetTypeGenerator<DoubleChanceFirstHalf>
    {
        public new const int ApiLabelId = 20;
        public new const string Name = "Double Chance - First Half";


        public DoubleChanceFirstHalfGenerator()
        {
        }

        public DoubleChanceFirstHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 20;
        }

        protected override void InitializeBetType()
        {
            BetType = new DoubleChanceFirstHalf();
        }
    }
}
