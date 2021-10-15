using Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType.Generators;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType
{
    public class BaseExactGoalsNumber : BaseBetType
    {
        public BaseExactGoalsNumber()
        {
            OddValues = ExactGoalsNumberOddValuesGenerator.GenerateExactGoalsNumberOddValues();
        }
    }
}
