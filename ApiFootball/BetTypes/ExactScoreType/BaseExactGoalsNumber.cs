using System;
using System.Collections.Generic;
using System.Text;
using ApiFootball.BetTypes.ExactScoreType.Generators;

namespace ApiFootball.BetTypes.ExactScoreType
{
    public class BaseExactGoalsNumber : BaseBetType
    {
        public BaseExactGoalsNumber()
        {
            OddValues = ExactGoalsNumberOddValuesGenerator.GenerateExactGoalsNumberOddValues();
        }
    }
}
