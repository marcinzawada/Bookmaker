using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Responses.Fixtures
{
    public class TeamResponse
    {
        [JsonProperty("team_id")]
        public int TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
