using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.BoolType.Generators
{
    public class BothTeamsScoreFSecondHalfGenerator : BaseBetTypeGenerator<BothTeamsScoreSecondHalf>
    {
        public new const int ApiLabelId = 35;
        public new const string Name = "Both Teams To Score - Second Half";


        public BothTeamsScoreFSecondHalfGenerator()
        {
        }

        public BothTeamsScoreFSecondHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 35;
        }

        protected override void InitializeBetType()
        {
            BetType = new BothTeamsScoreSecondHalf();
        }
    }
}
