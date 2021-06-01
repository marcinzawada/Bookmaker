using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.DTOs.Odds
{
    public class OddDto
    {
        [JsonProperty("fixture")]
        public FixtureDto Fixture { get; set; }

        [JsonProperty("bookmakers")]
        public List<BookieDto> Bookies { get; set; }
    }
}
