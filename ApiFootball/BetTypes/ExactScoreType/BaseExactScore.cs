using System;
using System.Collections.Generic;
using System.Text;
using ApiFootball.BetTypes.ExactScoreType.Generators;

namespace ApiFootball.BetTypes.ExactScoreType
{
    public class BaseExactScore : BaseBetType
    {
        public BaseExactScore()
        {
            OddValues = ExactScoreOddValuesGenerator.GoalsOverUnderOddValues();
        }
    }
}
