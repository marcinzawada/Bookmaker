using Domain.Entities;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.BoolType.Generators
{
    public class HomeTeamScoreGoalGenerator : BaseBetTypeGenerator<HomeTeamScoreGoal>
    {
        public new const int ApiLabelId = 43;
        public new const string Name = "Home Team Score a Goal";


        public HomeTeamScoreGoalGenerator()
        {
        }

        public HomeTeamScoreGoalGenerator(PotentialBet bet) : base(bet)
        {
        }

        protected override void SetLabelId()
        {
            ExtLabelId = 43;
        }

        protected override void InitializeBetType()
        {
            BetType = new HomeTeamScoreGoal();
        }
    }
}
