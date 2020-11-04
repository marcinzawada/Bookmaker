using System.Collections.Generic;

namespace ApiFootball.BetTypes.WinnerType
{
    public class BaseWinner : BaseBetType
    {
        public BaseWinner()
        {
            OddValues = new List<OddValue>
            {
                new OddValue()
                {
                    Value = "Home"
                },
                new OddValue()
                {
                    Value = "Draw"
                },
                new OddValue()
                {
                    Value = "Away"
                }
            };
        }
    }
}
