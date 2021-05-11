using System;
using Domain.Entities;

namespace ApiFootball.BetTypes.WinnerType
{
    public class HomeAwayGenerator : BaseBetTypeGenerator<HomeAway>
    {
        public new const int ApiLabelId = 2;
        public new const string Name = "Home/Away";


        public HomeAwayGenerator()
        {
        }

        public HomeAwayGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 2;
        }

        protected override void InitializeBetType()
        {
            BetType = new HomeAway();
        }
    }
}
