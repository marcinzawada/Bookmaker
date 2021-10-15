using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType.Generators
{
    public class SecondHalfWinnerGenerator : BaseBetTypeGenerator<BaseWinner>
    {
        public new const int ApiLabelId = 3;
        public new const string Name = "Second Half Winner";


        public SecondHalfWinnerGenerator()
        {
        }

        public SecondHalfWinnerGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 3;
        }

        protected override void InitializeBetType()
        {
            BetType =  new BaseWinner();
        }
    }
}
