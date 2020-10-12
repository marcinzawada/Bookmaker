using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Responses.Leagues
{
    public class FixturesResponse
    {
        [JsonProperty("events")]
        public bool Events { get; set; }

        [JsonProperty("lineups")]
        public bool Lineups { get; set; }

        [JsonProperty("statistics")]
        public bool Statistics { get; set; }

        [JsonProperty("players_statistics")]
        public bool PlayersStatistics { get; set; }
    }
}
