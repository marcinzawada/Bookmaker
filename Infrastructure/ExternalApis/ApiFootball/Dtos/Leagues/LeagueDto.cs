﻿using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Leagues
{
    public class LeagueDto
    {
        [JsonProperty("league_id")]
        public int LeagueId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("season_start")]
        public string SeasonStart { get; set; }

        [JsonProperty("season_end")]
        public string SeasonEnd { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("standings")]
        public bool Standings { get; set; }

        [JsonProperty("is_current")]
        public bool IsCurrent { get; set; }

        [JsonProperty("coverage")]
        public CoverageDto Coverage { get; set; }
    }
}
