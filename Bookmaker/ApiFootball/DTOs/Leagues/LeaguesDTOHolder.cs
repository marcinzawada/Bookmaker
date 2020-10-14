using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs.Leagues
{
    public class LeaguesDTOHolder
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("leagues")]
        public List<LeagueDTO> Leagues { get; set; }
    }
}
