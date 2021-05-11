﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace ApiFootball.BetTypes.BoolType.Generators
{
    public class BothTeamsScoreFirstHalfGenerator : BaseBetTypeGenerator<BothTeamsScoreSecondHalf>
    {
        public new const int ApiLabelId = 34;
        public new const string Name = "Both Teams Score - First Half";


        public BothTeamsScoreFirstHalfGenerator()
        {
        }

        public BothTeamsScoreFirstHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 34;
        }

        protected override void InitializeBetType()
        {
            BetType = new BothTeamsScoreSecondHalf();
        }
    }
}
