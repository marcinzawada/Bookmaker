using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.DTOs.Odds
{
    public class BookieDto
    {
        [JsonProperty("bookmaker_id")]
        public int BookieId { get; set; }

        [JsonProperty("bookmaker_name")]
        public string Name { get; set; }

        [JsonProperty("bets")]
        public List<BetDto> Bets { get; set; }
    }
}
