using Newtonsoft.Json;

namespace ApiFootball.DTOs.Leagues
{
    public class CoverageDto
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
        public FixturesDto Fixtures { get; set; }


    }
}
