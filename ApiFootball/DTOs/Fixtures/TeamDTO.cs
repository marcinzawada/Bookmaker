using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs.Fixtures
{
    public class TeamDTO
    {
        [JsonProperty("team_id")]
        public int TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
