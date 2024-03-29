﻿using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.BoolType.Generators
{
    public class CleanSheetAwayGenerator : BaseBetTypeGenerator<CleanSheetAway>
    {
        public new const int ApiLabelId = 28;
        public new const string Name = "Clean Sheet - Away";


        public CleanSheetAwayGenerator()
        {
        }

        public CleanSheetAwayGenerator(PotentialBet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 28;
        }

        protected override void InitializeBetType()
        {
            BetType = new CleanSheetAway();
        }
    }
}
