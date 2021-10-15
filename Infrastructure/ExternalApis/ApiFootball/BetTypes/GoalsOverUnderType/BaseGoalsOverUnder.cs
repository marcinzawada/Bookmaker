using Infrastructure.ExternalApis.ApiFootball.BetTypes.GoalsOverUnderType.Generators;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.GoalsOverUnderType
{
    public class BaseGoalsOverUnder : BaseBetType
    {
        public BaseGoalsOverUnder()
        {
            OddValues = GoalsOverUnderOddValuesGenerator.GoalsOverUnderOddValues();
        }
    }
}
