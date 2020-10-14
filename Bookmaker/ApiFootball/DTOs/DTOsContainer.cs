using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs
{
    public class DTOsContainer<T>
    {
        [JsonProperty("api")]
        public T DTOsHolder { get; set; }
    }
}
