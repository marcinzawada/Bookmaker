using Newtonsoft.Json;

namespace ApiFootball.DTOs
{
    public class DtoContainer<THolder>
    {
        [JsonProperty("api")]
        public THolder DtoHolder { get; set; }
    }
}
