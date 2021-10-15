using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.HandicapType.Generators
{
    public class HandicapFirstHalfGenerator : BaseBetTypeGenerator<AsianHandicapFirstHalf>
    {
        public new const int ApiLabelId = 19;
        public new const string Name = "Asian Handicap First Half";


        public HandicapFirstHalfGenerator()
        {
        }

        public HandicapFirstHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 19;
        }

        protected override void InitializeBetType()
        {
            BetType = new AsianHandicapFirstHalf();
        }
    }
}
