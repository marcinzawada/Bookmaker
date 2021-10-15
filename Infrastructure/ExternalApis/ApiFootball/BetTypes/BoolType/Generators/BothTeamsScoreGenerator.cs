using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.BoolType.Generators
{
    public class BothTeamsScoreGenerator : BaseBetTypeGenerator<BothTeamsScore>
    {
        public new const int ApiLabelId = 8;
        public new const string Name = "Both Teams Score";


        public BothTeamsScoreGenerator()
        {
        }

        public BothTeamsScoreGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 8;
        }

        protected override void InitializeBetType()
        {
            BetType = new BothTeamsScore();
        }
    }
}
