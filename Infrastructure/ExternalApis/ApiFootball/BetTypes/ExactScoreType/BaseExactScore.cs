using Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType.Generators;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType
{
    public class BaseExactScore : BaseBetType
    {
        public BaseExactScore()
        {
            OddValues = ExactScoreOddValuesGenerator.GoalsOverUnderOddValues();
        }
    }
}
