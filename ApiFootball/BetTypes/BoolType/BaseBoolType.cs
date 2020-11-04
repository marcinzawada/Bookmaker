using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.BetTypes.BoolType
{
    public class BaseBoolType : BaseBetType
    {
        public BaseBoolType()
        {
            OddValues = new List<OddValue>
            {
                new OddValue
                {
                    Value = "Yes"
                },
                new OddValue
                {
                    Value = "No"
                },
            };
        }
    }
}
