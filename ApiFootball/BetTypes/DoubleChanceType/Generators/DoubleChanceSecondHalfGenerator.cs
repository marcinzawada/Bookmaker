using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Models;

namespace ApiFootball.BetTypes.DoubleChanceType.Generators
{
    public class DoubleChanceSecondHalfGenerator : BaseBetTypeGenerator<DoubleChanceSecondHalf>
    {
        public new const int ApiLabelId = 33;
        public new const string Name = "Double Chance Second Half";


        public DoubleChanceSecondHalfGenerator()
        {
        }

        public DoubleChanceSecondHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 33;
        }

        protected override void InitializeBetType()
        {
            BetType = new DoubleChanceSecondHalf();
        }
    }
}
