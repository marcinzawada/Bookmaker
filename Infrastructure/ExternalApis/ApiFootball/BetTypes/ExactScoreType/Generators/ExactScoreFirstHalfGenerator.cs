using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType.Generators
{
    public class ExactScoreFirstHalfGenerator : BaseBetTypeGenerator<ExactScoreFirstHalf>
    {
        public new const int ApiLabelId = 31;
        public new const string Name = "Exact Score First Half";


        public ExactScoreFirstHalfGenerator()
        {
        }

        public ExactScoreFirstHalfGenerator(Bet bet) : base(bet)
        {
        }


        protected override void SetLabelId()
        {
            ExtLabelId = 31;
        }

        protected override void InitializeBetType()
        {
            BetType = new ExactScoreFirstHalf();
        }
    }
}
