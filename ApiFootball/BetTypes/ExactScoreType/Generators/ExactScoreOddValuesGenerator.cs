using System.Collections.Generic;

namespace ApiFootball.BetTypes.ExactScoreType.Generators
{
    public sealed class ExactScoreOddValuesGenerator
    {
        public static List<OddValue> GoalsOverUnderOddValues()
        {
            var goals = new List<string>();
            for (var i = 0; i <= 10; i++)
            {
                for (var j = 0; j <= 10; j++)
                {
                    goals.Add(i + ":" + j);
                    goals.Add(j + ":" + i);
                }
            }

            List<OddValue> oddValues = new List<OddValue>();

            foreach (var goal in goals)
            {
                oddValues.Add(new OddValue
                {
                    Value = goal
                });
            }

            return oddValues;
        }
    }
}
