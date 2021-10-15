using System.Collections.Generic;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.GoalsOverUnderType.Generators
{
    public static class GoalsOverUnderOddValuesGenerator
    {
        public static List<OddValue> GoalsOverUnderOddValues()
        {
            var goals = new List<float>();
            for (float i = 1; i <= 20; i++)
            {
                goals.Add(i/2);
            }

            List<OddValue> oddValues = new List<OddValue>();

            foreach (var goal in goals)
            {
                var parsedGoal = goal.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);

                oddValues.Add(new OddValue()
                {
                    Value = $"Over {parsedGoal}" 
                });

                oddValues.Add(new OddValue()
                {
                    Value = $"Under {parsedGoal}"
                });
            }

            return oddValues;
        }
    }
}
