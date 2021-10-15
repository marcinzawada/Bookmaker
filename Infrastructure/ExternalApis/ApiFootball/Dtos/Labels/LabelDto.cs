using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Labels
{
    public class LabelDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Name { get; set; }
    }
}
