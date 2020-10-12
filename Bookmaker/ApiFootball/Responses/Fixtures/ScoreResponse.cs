using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Responses.Fixtures
{
    public class ScoreResponse
    {
        [JsonProperty("halftime")]
        public string Halftime { get; set; }

        [JsonProperty("fulltime")]
        public string Fulltime { get; set; }

        [JsonProperty("extratime")]
        public string Extratime { get; set; }

        [JsonProperty("penalty")]
        public string Penalty { get; set; }
    }
}
