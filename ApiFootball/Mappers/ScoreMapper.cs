using Api.Data.Models;
using Bookmaker.Api.Data.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ApiFootball.DTOs.Fixtures;

namespace ApiFootball.Mappers
{
    class ScoreMapper : BaseMapper, IDtoToModelMapper<FixtureDto, Api.Data.Models.Score>
    {
        private readonly ILogger<ScoreMapper> _logger;


        public ScoreMapper(AppDbContext context, ILogger<ScoreMapper> logger) : base(context)
        {
            _logger = logger;
        }

        public Score MapDtoToModel(FixtureDto dto)
        {
            var matchScores = GetMatchScores(dto);
            return CreateScore(dto, matchScores);
        }

        public Score CreateScore(FixtureDto dto,
            MatchScores matchScores)
        {
            return new Score
            {
                GoalsHomeTeam = dto.GoalsHomeTeam,
                GoalsAwayTeam = dto.GoalsAwayTeam,
                HalftimeHomeGoals = matchScores.HalfTimeScore.Home,
                HalftimeAwayGoals = matchScores.HalfTimeScore.Away,
                FulltimeHomeGoals = matchScores.FullTimeScore.Home,
                FulltimeAwayGoals = matchScores.FullTimeScore.Away,
                ExtratimeHomeGoals = matchScores.ExtraTimeScore.Home,
                ExtratimeAwayGoals = matchScores.ExtraTimeScore.Away,
                PenaltyHomeGoals = matchScores.PenaltyScore.Home,
                PenaltyAwayGoals = matchScores.PenaltyScore.Away
            };
        }

        private MatchScores GetMatchScores(FixtureDto dto)
        {
            return new MatchScores
            {
                FullTimeScore = ParseScore(dto.Score.Fulltime, dto.LeagueId),
                HalfTimeScore = ParseScore(dto.Score.Halftime, dto.LeagueId),
                ExtraTimeScore = ParseScore(dto.Score.Extratime, dto.LeagueId),
                PenaltyScore = ParseScore(dto.Score.Penalty, dto.LeagueId)
            };
        }

        private ScoreValue ParseScore(string matchScores, int extFixtureId)
        {
            var splittedScores = matchScores.Split("-");

            var homeScoreIsCorrect =
                Int32.TryParse(splittedScores[0], out var homeScore);
            var awayScoreIsCorrect =
                Int32.TryParse(splittedScores[0], out var awayScore);

            var score = new ScoreValue
            {
                Home = homeScore,
                Away = awayScore
            };

            if (!homeScoreIsCorrect || !awayScoreIsCorrect)
            {
                _logger.LogError("Failed parsing score," +
                    " ExtFixtureId: " + extFixtureId);

                if (!homeScoreIsCorrect)
                    score.Home = -1;
                if (!awayScoreIsCorrect)
                    score.Away = -1;
            }

            return score;
        }

        internal class MatchScores
        {
            public ScoreValue HalfTimeScore { get; set; }

            public ScoreValue FullTimeScore { get; set; }

            public ScoreValue ExtraTimeScore { get; set; }

            public ScoreValue PenaltyScore { get; set; }
        }

        internal class ScoreValue
        {
            public int Home { get; set; }

            public int Away { get; set; }
        }
    }
}
