using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType.Generators
{
    public class HomeAwayGenerator : BaseBetTypeGenerator<HomeAway>
    {
        public new const int ApiLabelId = 2;
        public new const string Name = "Home/Away";


        public HomeAwayGenerator()
        {
        }

        public HomeAwayGenerator(PotentialBet bet) : base(bet)
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
