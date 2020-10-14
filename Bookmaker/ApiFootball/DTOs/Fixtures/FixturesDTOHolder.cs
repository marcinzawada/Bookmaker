using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs.Fixtures
{
    public class FixturesDTOHolder
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("fixtures")]
        public List<FixtureDTO> Fixtures { get; set; }
    }
}
