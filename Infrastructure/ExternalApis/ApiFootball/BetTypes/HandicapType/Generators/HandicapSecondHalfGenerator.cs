using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.HandicapType.Generators
{
    public class HandicapSecondHalfGenerator : BaseBetTypeGenerator<AsianHandicap>
    {
        public new const int ApiLabelId = 4;
        public new const string Name = "Asian HandicapAsian Handicap";


        public HandicapSecondHalfGenerator()
        {
        }

        public HandicapSecondHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 4;
        }

        protected override void InitializeBetType()
        {
            BetType = new AsianHandicap();
        }
    }
}
