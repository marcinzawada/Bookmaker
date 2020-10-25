﻿using Newtonsoft.Json;

namespace ApiFootball.DTOs.Leagues
{
    public class FixturesDto
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
