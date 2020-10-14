using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball
{
    public class STH : BaseXD
    {
        [JsonProperty("resources")]
        public List<STH> Resources { get; set; }
    }
}
