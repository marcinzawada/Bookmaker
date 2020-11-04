﻿using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Models;

namespace ApiFootball.BetTypes.BoolType.Generators
{
    public class AwayTeamScoreGoalGenerator : BaseBetTypeGenerator<AwayTeamScoreGoal>
    {
        public new const int ApiLabelId = 44;
        public new const string Name = "Away Team Score a Goal";


        public AwayTeamScoreGoalGenerator()
        {
        }

        public AwayTeamScoreGoalGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 44;
        }

        protected override void InitializeBetType()
        {
            BetType = new AwayTeamScoreGoal();
        }
    }
}
