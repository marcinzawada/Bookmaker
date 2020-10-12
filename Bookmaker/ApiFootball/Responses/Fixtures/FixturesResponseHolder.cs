using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Responses.Fixtures
{
    public class FixturesResponseHolder
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("fixtures")]
        public List<FixtureResponse> Fixtures { get; set; }
    }
}
