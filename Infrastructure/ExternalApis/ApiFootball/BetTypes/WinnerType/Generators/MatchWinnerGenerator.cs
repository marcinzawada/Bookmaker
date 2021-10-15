using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType.Generators
{
    public class MatchWinnerGenerator : BaseBetTypeGenerator<MatchWinner>
    {
        public new const int ApiLabelId = 1;
        public new const string Name = "Match Winner";


        public MatchWinnerGenerator()
        {
        }

        public MatchWinnerGenerator(Bet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 1;
        }

        protected override void InitializeBetType()
        {
            BetType = new MatchWinner();
        }
    }
}
