﻿using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures
{
    public class LeagueDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}
