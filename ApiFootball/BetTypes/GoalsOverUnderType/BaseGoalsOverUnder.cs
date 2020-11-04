using System;
using System.Collections.Generic;
using System.Text;
using ApiFootball.BetTypes.GoalsOverUnderType.Generators;

namespace ApiFootball.BetTypes.GoalsOverUnderType
{
    public class BaseGoalsOverUnder : BaseBetType
    {
        public BaseGoalsOverUnder()
        {
            OddValues = GoalsOverUnderOddValuesGenerator.GoalsOverUnderOddValues();
        }
    }
}
