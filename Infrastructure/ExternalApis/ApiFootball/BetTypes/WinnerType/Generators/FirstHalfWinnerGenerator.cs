using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType.Generators
{
    public class FirstHalfWinnerGenerator : BaseBetTypeGenerator<FirstHalfWinner>
    {
        public new const int ApiLabelId = 13;
        public new const string Name = "Second Half Winner";


        public FirstHalfWinnerGenerator()
        {
        }

        public FirstHalfWinnerGenerator(PotentialBet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 13;
        }

        protected override void InitializeBetType()
        {
            BetType = new FirstHalfWinner();
        }
    }
}
