﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.DTOs.Fixtures
{
    public class FixtureDTO
    {
        [JsonProperty("fixture_id")]
        public int FixtureId { get; set; }

        [JsonProperty("league_id")]
        public int LeagueId { get; set; }

        [JsonProperty("league")]
        public LeagueDTO League { get; set; }

        [JsonProperty("event_date")]
        public string EventDate { get; set; }

        [JsonProperty("event_timestamp")]
        public long EventTimestamp { get; set; }

        [JsonProperty("firstHalfStart")]
        public long FirstHalfStart { get; set; }

        [JsonProperty("secondHalfStart")]
        public long SecondHalfStart { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusShort")]
        public string StatusShort { get; set; }

        [JsonProperty("elapsed")]
        public int Elapsed { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("referee")]
        public string Referee { get; set; }

        [JsonProperty("homeTeam")]
        public TeamDTO HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public TeamDTO AwayTeam { get; set; }

        [JsonProperty("goalsHomeTeam")]
        public int GoalsHomeTeam { get; set; }

        [JsonProperty("goalsAwayTeam")]
        public int GoalsAwayTeam { get; set; }

        [JsonProperty("score")]
        public ScoreDTO Score { get; set; }
    }
}