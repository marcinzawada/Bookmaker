using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.DTOs.Fixtures.Rounds
{
    class RoundDto
    {
        [JsonProperty("fixtures")]
        public List<string> Name { get; set; }
    }
}
