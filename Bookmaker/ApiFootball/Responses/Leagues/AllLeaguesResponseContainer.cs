using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Responses.Leagues
{
    public class AllLeaguesResponseContainer
    {
        [JsonProperty("api")]
        public AllLeaguesResponse AllLeaguesResponse { get; set; }
    }
}
