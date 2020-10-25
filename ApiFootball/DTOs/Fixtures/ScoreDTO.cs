using Newtonsoft.Json;

namespace ApiFootball.DTOs.Fixtures
{
    public class ScoreDto
    {
        [JsonProperty("halftime")]
        public string Halftime { get; set; }

        [JsonProperty("fulltime")]
        public string Fulltime { get; set; }

        [JsonProperty("extratime")]
        public string Extratime { get; set; }

        [JsonProperty("penalty")]
        public string Penalty { get; set; }
    }
}
