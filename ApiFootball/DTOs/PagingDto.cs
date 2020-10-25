using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.DTOs
{
    public class PagingDto
    {
        [JsonProperty("current")]
        public int CurrentPage { get; set; }

        [JsonProperty("total")]
        public int TotalPages { get; set; }
    }
}
