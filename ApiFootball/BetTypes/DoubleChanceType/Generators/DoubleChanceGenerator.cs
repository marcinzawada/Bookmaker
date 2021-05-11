using System;
using System.Collections.Generic;
using System.Text;
using ApiFootball.BetTypes.ExactScoreType;
using Domain.Entities;

namespace ApiFootball.BetTypes.DoubleChanceType.Generators
{
    public class DoubleChanceGenerator : BaseBetTypeGenerator<DoubleChance>
    {
        public new const int ApiLabelId = 12;
        public new const string Name = "Double Chance";


        public DoubleChanceGenerator()
        {
        }

        public DoubleChanceGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 12;
        }

        protected override void InitializeBetType()
        {
            BetType = new DoubleChance();
        }
    }
}
