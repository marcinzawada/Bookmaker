using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.DTOs.Odds
{
    class OddDto
    {
        [JsonProperty("fixture")]
        public FixtureDto Fixture { get; set; }

        [JsonProperty("bookmakers")]
        public List<BookieDto> Bookies { get; set; }
    }
}
