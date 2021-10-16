using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.GoalsOverUnderType.Generators
{
    public class GoalsOverUnderGenerator : BaseBetTypeGenerator<GoalsOverUnder>
    {
        public new const int ApiLabelId = 5;
        public new const string Name = "Goals Over/Under";


        public GoalsOverUnderGenerator()
        {
        }

        public GoalsOverUnderGenerator(PotentialBet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 5;
        }

        protected override void InitializeBetType()
        {
            BetType = new GoalsOverUnder();
        }
    }
}
