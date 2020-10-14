using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs.Leagues
{
    public class CoverageDTO
    {
        [JsonProperty("standings")]
        public bool CoverageStandings { get; set; }

        [JsonProperty("players")]
        public bool Players { get; set; }

        [JsonProperty("topScorers")]
        public bool TopScorers { get; set; }

        [JsonProperty("predictions")]
        public bool Predictions { get; set; }

        [JsonProperty("odds")]
        public bool Odds { get; set; }

        [JsonProperty("fixtures")]
        public FixturesDTO Fixtures { get; set; }


    }
}
