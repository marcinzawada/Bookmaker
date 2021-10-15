using System.Collections.Generic;

namespace Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType
{
    public class HomeAway : BaseBetType
    {
        public new const string Name = "Home/Away";


        public HomeAway()
        {
            OddValues = new List<OddValue>
            {
                new OddValue()
                {
                    Value = "Home"
                },
                new OddValue()
                {
                    Value = "Away"
                }
            };
        }
    }
}
