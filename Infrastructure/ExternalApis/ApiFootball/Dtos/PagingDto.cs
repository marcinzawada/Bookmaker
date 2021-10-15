using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos
{
    public class PagingDto
    {
        [JsonProperty("current")]
        public int CurrentPage { get; set; }

        [JsonProperty("total")]
        public int TotalPages { get; set; }
    }
}
