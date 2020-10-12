using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Responses
{
    public class ResponseContainer<T>
    {
        [JsonProperty("api")]
        public T Content { get; set; }
    }
}
