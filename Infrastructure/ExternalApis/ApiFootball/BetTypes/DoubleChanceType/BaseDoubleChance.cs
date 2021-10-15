using System.Collections.Generic;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.DoubleChanceType
{
    public class BaseDoubleChance : BaseBetType
    {
        public BaseDoubleChance()
        {
            OddValues = new List<OddValue>
            {
                new OddValue
                {
                    Value = "Home/Draw",
                },
                new OddValue
                {
                    Value = "Home/Away",
                },
                new OddValue
                {
                    Value = "Draw/Away",
                }
            };
        }
    }
}
