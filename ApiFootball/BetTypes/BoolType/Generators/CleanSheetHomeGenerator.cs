using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace ApiFootball.BetTypes.BoolType.Generators
{
    public class CleanSheetHomeGenerator : BaseBetTypeGenerator<CleanSheetHome>
    {
        public new const int ApiLabelId = 27;
        public new const string Name = "Clean Sheet - Home";


        public CleanSheetHomeGenerator()
        {
        }

        public CleanSheetHomeGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 27;
        }

        protected override void InitializeBetType()
        {
            BetType = new CleanSheetHome();
        }
    }
}
