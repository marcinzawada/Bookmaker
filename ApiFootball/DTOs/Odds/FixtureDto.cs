using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.DTOs.Odds
{
    public class FixtureDto
    {
        [JsonProperty("league_id")]
        public int LeagueId { get; set; }

        [JsonProperty("fixture_id")]
        public int FixtureId { get; set; }

        [JsonProperty("updateAt")]
        public long UpdateAt { get; set; }
    }
}
