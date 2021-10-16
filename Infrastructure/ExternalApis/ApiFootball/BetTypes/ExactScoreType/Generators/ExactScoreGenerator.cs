using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType.Generators
{
    public class ExactScoreGenerator : BaseBetTypeGenerator<ExactScore>
    {
        public new const int ApiLabelId = 10;
        public new const string Name = "Exact Score";

        public ExactScoreGenerator()
        {
        }

        public ExactScoreGenerator(PotentialBet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 10;
        }

        protected override void InitializeBetType()
        {
            BetType = new ExactScore();
        }
    }
}
