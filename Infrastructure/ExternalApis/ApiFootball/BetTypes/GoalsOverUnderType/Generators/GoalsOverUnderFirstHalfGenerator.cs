using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.GoalsOverUnderType.Generators
{
    public class GoalsOverUnderFirstHalfGenerator : BaseBetTypeGenerator<GoalsOverUnderFirstHalf>
    {
        public new const int ApiLabelId = 6;
        public new const string Name = "Second Half Winner";


        public GoalsOverUnderFirstHalfGenerator()
        {
        }

        public GoalsOverUnderFirstHalfGenerator(PotentialBet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 6;
        }

        protected override void InitializeBetType()
        {
            BetType = new GoalsOverUnderFirstHalf();
        }
    }
}
