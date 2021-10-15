using Newtonsoft.Json;

namespace Infrastructure.ExternalApis.ApiFootball.Dtos.Teams
{
    public class TeamDto
    {
        [JsonProperty("team_id")]
        public int TeamId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public int LeagueId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("is_national")]
        public bool IsNational { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("founded")]
        public int? Founded { get; set; }

        [JsonProperty("venue_name")]
        public string VenueName { get; set; }

        [JsonProperty("venue_surface")]
        public string VenueSurface { get; set; }

        [JsonProperty("venue_address")]
        public string VenueAddress { get; set; }

        [JsonProperty("venue_city")]
        public string VenueCity { get; set; }

        [JsonProperty("venue_capacity")]
        public int? VenueCapacity { get; set; }
    }
}
