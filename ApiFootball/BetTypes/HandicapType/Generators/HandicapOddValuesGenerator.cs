using System.Collections.Generic;

namespace ApiFootball.BetTypes.HandicapType.Generators
{
    public static class HandicapOddValuesGenerator
    {
        public static List<OddValue> GenerateHandicapOddValues()
        {
            var goals = new List<string> {"Home +0", "Away +0"};
            for (float i = 1; i <= 20; i++)
            {
                goals.Add("Home +" + i/2);
                goals.Add("Home -" + i/2);
                goals.Add("Away +" + i/2);
                goals.Add("Away -" + i/2);
            }

            var oddValues = new List<OddValue>();

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
