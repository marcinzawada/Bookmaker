using System.Collections.Generic;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.BoolType
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
