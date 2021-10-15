using Infrastructure.ExternalApis.ApiFootball.BetTypes.HandicapType.Generators;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.HandicapType
{
    public class BaseHandicap : BaseBetType
    {
        public BaseHandicap()
        {
            OddValues = HandicapOddValuesGenerator.GenerateHandicapOddValues();
        }
    }
}
