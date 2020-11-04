using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.BetTypes
{
    public abstract class BaseBetType
    {
        public const string Name = "BaseBetType";

        public int OddId { get; set; }

        public int LabelId { get; set; }


        public List<OddValue> OddValues { get; set; } = new List<OddValue>();
    }
}
