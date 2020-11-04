using ApiFootball.BetTypes.HandicapType.Generators;

namespace ApiFootball.BetTypes.HandicapType
{
    public class BaseHandicap : BaseBetType
    {
        public BaseHandicap()
        {
            OddValues = HandicapOddValuesGenerator.GenerateHandicapOddValues();
        }
    }
}
