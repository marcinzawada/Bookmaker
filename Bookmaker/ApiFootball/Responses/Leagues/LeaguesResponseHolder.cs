using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Responses.Leagues
{
    public class LeaguesResponseHolder
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("leagues")]
        public List<LeagueResponse> Leagues { get; set; }
    }
}
