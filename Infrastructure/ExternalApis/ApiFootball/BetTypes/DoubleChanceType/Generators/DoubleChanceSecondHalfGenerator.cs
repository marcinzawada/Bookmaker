using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.DoubleChanceType.Generators
{
    public class DoubleChanceSecondHalfGenerator : BaseBetTypeGenerator<DoubleChanceSecondHalf>
    {
        public new const int ApiLabelId = 33;
        public new const string Name = "Double Chance Second Half";


        public DoubleChanceSecondHalfGenerator()
        {
        }

        public DoubleChanceSecondHalfGenerator(PotentialBet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 33;
        }

        protected override void InitializeBetType()
        {
            BetType = new DoubleChanceSecondHalf();
        }
    }
}
