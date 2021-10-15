using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Odds
{
    public class BetDto
    {
        [JsonProperty("label_id")]
        public int LabelId { get; set; }

        [JsonProperty("label_name")]
        public string LabelName { get; set; }

        [JsonProperty("values")]
        public List<BetValueDto> BetValues { get; set; }
    }
}
