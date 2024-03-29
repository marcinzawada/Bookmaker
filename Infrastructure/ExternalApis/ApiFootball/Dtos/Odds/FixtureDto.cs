﻿using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Odds
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
