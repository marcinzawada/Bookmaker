using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.DTOs.Odds
{
    public class BetValueDto
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("odd")]
        public string Odd { get; set; }
    }
}
