using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
{
    public class FixturesMapper : BaseMapper, IDtoToModelMapper<FixtureDto, Fixture>
    {
        private readonly ILogger<LeagueMapper> _logger;

        public FixturesMapper(AppDbContext context, ILogger<LeagueMapper> logger)
            : base(context)
        {
            _logger = logger;
        }

        public Fixture MapDtoToModel(FixtureDto dto)
        {
            var homeTeamId = GetTeamIdByExtTeamId(dto.HomeTeam.TeamId);
            var awayTeamId = GetTeamIdByExtTeamId(dto.AwayTeam.TeamId);

            var leagueId = GetLeagueIdByExtLeagueId(dto.LeagueId);

            var eventDates = GetEventDates(dto);

            var roundId = GetRoundIdByNameAndLeagueId(dto.Round, leagueId);

            var matchStatus = ParseMatchStatusType(dto);

            return CreateFixture(dto, homeTeamId, awayTeamId,
                leagueId, eventDates, roundId, matchStatus);
        }

        public List<Fixture> MapDtosToModels(List<FixtureDto> dtos)
        {
            var fixtures = new List<Fixture>();

            foreach (var fixtureDto in dtos)
            {
                fixtures.Add(MapDtoToModel(fixtureDto));
            }

            return fixtures;
        }

        private Fixture CreateFixture(FixtureDto dto, int homeTeamId,
            int awayTeamId, int leagueId, EventDates eventDates,
            int? roundId, MatchStatus matchStatus)
        {
            var fixture = new Fixture
            {
                ExtFixtureId = dto.FixtureId,
                LeagueId = leagueId,
                EventDate = eventDates.MatchStart,
                FirstHalfStart = eventDates.FirstHalfStart,
                SecondHalfStart = eventDates.SecondHalfStart,
                RoundId = roundId,
                Elapsed = dto.Elapsed,
                Venue = dto.Venue,
                Referee = dto.Referee,
                Status = matchStatus,
                StatusName = dto.Status,
                HomeTeamId = homeTeamId,
                AwayTeamId = awayTeamId,
                CreatedAt = DateTime.UtcNow
            };

            return fixture;
        }

        private int GetTeamIdByExtTeamId(int extTeamId)
        {
            var team =
                _context.Teams.FirstOrDefault(
                    x => x.ExtTeamId == extTeamId);

            if (team != null)
                return team.Id;

            _logger.LogError(
                "No team found for ExtTeamId:" + extTeamId);

            return 0;
        }

        private int GetLeagueIdByExtLeagueId(int extLeagueId)
        {
            var league =
                _context.Leagues.FirstOrDefault(
                    x => x.ExtLeagueId == extLeagueId);

            if (league != null)
                return league.Id;

            _logger.LogError(
                "No league found for ExtLeagueId:" + extLeagueId);

            return 0;
        }

        private EventDates GetEventDates(FixtureDto dto)
        {
            return new EventDates
            {
                MatchStart = GetDateTimeByTimeByTimestamp(dto.EventTimestamp),
                FirstHalfStart = GetDateTimeByTimeByTimestamp(dto.FirstHalfStart),
                SecondHalfStart = GetDateTimeByTimeByTimestamp(dto.SecondHalfStart)
            };
        }

        private DateTime? GetDateTimeByTimeByTimestamp(long? timestamp)
        {
            if (timestamp == null)
                return null;

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds((double)timestamp).ToLocalTime();
            return dateTime;
        }

        private int? GetRoundIdByNameAndLeagueId(
            string roundName, int leagueId)
        {
            var round = _context.Rounds.FirstOrDefault(
                x => x.LeagueId == leagueId && x.Name.ToLower() == roundName.ToLower());

            if (round != null)
                return round.Id;

            _logger.LogError(
                "No round found for roundName: " + roundName +
                " and leagueId: " + leagueId);

            return null;

        }

        private MatchStatus ParseMatchStatusType(FixtureDto dto)
        {
            switch (dto.StatusShort)
            {
                case "1H":
                    return MatchStatus.H2;
                case "2H":
                    return MatchStatus.H1;
            }

            var isMatchStatusCorrect = Enum.TryParse<MatchStatus>(dto.StatusShort, true, out var matchStatus);

            if (isMatchStatusCorrect)
                return matchStatus;

            matchStatus = MatchStatus.TBD;

            _logger.LogError("Invalid MatchStatus from api: " +
                             dto.StatusShort + "ExtLeagueId: " + dto.LeagueId);

            return matchStatus;
        }
    }

    internal class EventDates
    {
        public DateTime? MatchStart { get; set; }

        public DateTime? FirstHalfStart { get; set; }

        public DateTime? SecondHalfStart { get; set; }
    }


}
