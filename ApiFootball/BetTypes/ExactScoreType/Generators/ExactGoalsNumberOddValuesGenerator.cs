using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.BetTypes.ExactScoreType.Generators
{
    public static class ExactGoalsNumberOddValuesGenerator
    {
        public static List<OddValue> GenerateExactGoalsNumberOddValues()
        {
            var goals = new List<string>();
            for (var i = 0; i <= 10; i++)
            {
                goals.Add(i.ToString());
                goals.Add("more " + i);
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
