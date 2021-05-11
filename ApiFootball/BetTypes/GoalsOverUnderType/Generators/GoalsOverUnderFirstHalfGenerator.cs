using System;
using Domain.Entities;

namespace ApiFootball.BetTypes.GoalsOverUnderType.Generators
{
    public class GoalsOverUnderFirstHalfGenerator : BaseBetTypeGenerator<GoalsOverUnderFirstHalf>
    {
        public new const int ApiLabelId = 6;
        public new const string Name = "Second Half Winner";


        public GoalsOverUnderFirstHalfGenerator()
        {
        }

        public GoalsOverUnderFirstHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 6;
        }

        protected override void InitializeBetType()
        {
            BetType = new GoalsOverUnderFirstHalf();
        }
    }
}
