using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace ApiFootball.BetTypes.GoalsOverUnderType.Generators
{
    public class GoalsOverUnderSecondHalfGenerator : BaseBetTypeGenerator<GoalsOverUnderSecondHalf>
    {
        public new const int ApiLabelId = 26;
        public new const string Name = "Second Half Winner";


        public GoalsOverUnderSecondHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 26;
        }

        protected override void InitializeBetType()
        {
            BetType = new GoalsOverUnderSecondHalf();
        }
    }
}
