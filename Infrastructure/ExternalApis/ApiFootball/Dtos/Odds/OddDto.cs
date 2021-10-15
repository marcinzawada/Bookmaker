using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Odds
{
    public class OddDto
    {
        [JsonProperty("fixture")]
        public FixtureDto Fixture { get; set; }

        [JsonProperty("bookmakers")]
        public List<BookieDto> Bookies { get; set; }
    }
}
