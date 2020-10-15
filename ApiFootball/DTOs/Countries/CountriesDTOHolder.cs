using Bookmaker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs.Countries
{
    public class CountriesDTOHolder
    {
        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("countries")]
        public List<Country> Countries { get; set; }
    }
}
