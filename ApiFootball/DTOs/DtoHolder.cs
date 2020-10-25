using System.Collections.Generic;
using Bookmaker.ApiFootball.DTOs;
using Newtonsoft.Json;

namespace ApiFootball.DTOs
{
    [JsonConverter(typeof(DtoHolderConverter))]
    public class DtoHolder<TDto>
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("resources")]
        public List<TDto> Resources { get; set; }

        [JsonProperty("paging")]
        public PagingDto Paging { get; set; }
    }
}
