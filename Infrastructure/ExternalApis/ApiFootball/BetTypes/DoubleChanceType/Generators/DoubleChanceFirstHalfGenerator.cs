using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.DoubleChanceType.Generators
{
    public class DoubleChanceFirstHalfGenerator : BaseBetTypeGenerator<DoubleChanceFirstHalf>
    {
        public new const int ApiLabelId = 20;
        public new const string Name = "Double Chance - First Half";


        public DoubleChanceFirstHalfGenerator()
        {
        }

        public DoubleChanceFirstHalfGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 20;
        }

        protected override void InitializeBetType()
        {
            BetType = new DoubleChanceFirstHalf();
        }
    }
}
