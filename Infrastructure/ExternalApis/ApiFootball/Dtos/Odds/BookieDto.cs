using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Odds
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
