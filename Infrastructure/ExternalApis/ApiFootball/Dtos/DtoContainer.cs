using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos
{
    public class DtoContainer<THolder>
    {
        [JsonProperty("api")]
        public THolder DtoHolder { get; set; }
    }
}
