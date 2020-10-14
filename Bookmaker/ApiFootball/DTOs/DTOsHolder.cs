using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs
{
    [JsonConverter(typeof(DTOsHolderConverter))]
    public class DTOsHolder<DTO>
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("resources")]
        public List<DTO> Resources { get; set; }
    }
}
