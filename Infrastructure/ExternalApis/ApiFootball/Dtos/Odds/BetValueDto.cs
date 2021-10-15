using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Odds
{
    public class BetValueDto
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("odd")]
        public string Odd { get; set; }
    }
}
