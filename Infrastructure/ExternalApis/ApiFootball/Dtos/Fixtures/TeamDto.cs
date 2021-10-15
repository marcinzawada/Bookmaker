using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures
{
    public class TeamDto
    {
        [JsonProperty("team_id")]
        public int TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
