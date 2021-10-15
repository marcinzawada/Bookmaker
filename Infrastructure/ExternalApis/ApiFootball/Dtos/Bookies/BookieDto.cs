using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Bookies
{
    public class BookieDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } 
    }
}
