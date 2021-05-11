using Bookmaker.Api.Data.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Api.Data.Enums;
using ApiFootball.DTOs.Leagues;
using Domain.Entities;

namespace ApiFootball.Mappers
{
    public class LeagueMapper : BaseMapper, IDtoToModelMapper<LeagueDto, League>
    {
        private readonly ILogger<LeagueMapper> _logger;

        public LeagueMapper(ILogger<LeagueMapper> logger, AppDbContext context) 
            : base(context) 
        {
            _logger = logger;
        }

        public League MapDtoToModel(LeagueDto dto)
        {
            var leagueType = ParseLeagueType(dto);

            var isSeasonStartCorrect = ParseDate(dto.SeasonStart, out DateTime seasonStart);
            seasonStart = MarkDateSeasonIncorrect(isSeasonStartCorrect, seasonStart, dto);

            var isSeasonEndCorrect = ParseDate(dto.SeasonStart, out DateTime seasonEnd);
            seasonEnd = MarkDateSeasonIncorrect(isSeasonEndCorrect, seasonEnd, dto);

            var countryId = GetCountryIdByName(dto.Country);

            var seasonId = GetSeasonIdByYear(dto);

            return CreateLeague(dto, leagueType, seasonStart, seasonEnd, countryId, seasonId);
        }

        public List<League> MapDtosToModels(List<LeagueDto> dtos)
        {
            var leagues = new List<League>();

            foreach (var leagueDto in dtos)
            {
                leagues.Add(MapDtoToModel(leagueDto));
            }

            return leagues;
        }

        private LeagueType ParseLeagueType(LeagueDto leagueDto)
        {
            var isLeagueTypeCorrect = Enum.TryParse<LeagueType>(leagueDto.Type, true, out LeagueType leagueType);
            if (!isLeagueTypeCorrect)
            {
                leagueType = LeagueType.OTHER;
                _logger.LogError("Invalid LeagueType from api: " +
                    leagueDto.Type + "ExtLeagueId: " + leagueDto.Type);
            }
            return leagueType;
        }

        private DateTime MarkDateSeasonIncorrect(bool dateIsCorrect, DateTime date, LeagueDto leagueDto)
        {
            if (dateIsCorrect)
                return date;

            _logger.LogWarning("Invalid season date. ExtLeagueId: " + leagueDto.LeagueId);
            
            return date;
        }

        private int? GetCountryIdByName(string countryName)
        {
            return _context.Countries.FirstOrDefault(
                x => x.Name == countryName)?.Id;
        }

        private int GetSeasonIdByYear(LeagueDto dto)
        {
            var season = _context.Seasons.FirstOrDefault(
                x => x.Year == dto.Season);

            if (season != null)
                return season.Id;

            _logger.LogError("No season for league. ExtLeagueId: " + dto.LeagueId);
            return 1;
        }

        private League CreateLeague(LeagueDto leagueDto, LeagueType leagueType,
            DateTime seasonStart, DateTime seasonEnd, int? countryId, int seasonId)
        {
            return new League
            {
                Name = leagueDto.Name,
                ExtLeagueId = leagueDto.LeagueId,
                SportId = 1,
                Type = leagueType,
                CountryId = countryId,
                CountryCode = leagueDto.CountryCode,
                SeasonId = seasonId,
                SeasonStart = seasonStart,
                SeasonEnd = seasonEnd,
                Logo = leagueDto.Logo,
                Flag = leagueDto.Flag,
                HasStandings = leagueDto.Standings,
                IsCurrent = leagueDto.IsCurrent,
                HasCoverageStandings = leagueDto.Coverage.CoverageStandings,
                HasPlayers = leagueDto.Coverage.Players,
                HasTopScorers = leagueDto.Coverage.TopScorers,
                HasPredictions = leagueDto.Coverage.Predictions,
                HasOdds = leagueDto.Coverage.Odds,
                HasEvents = leagueDto.Coverage.Fixtures.Events,
                HasLineups = leagueDto.Coverage.Fixtures.Lineups,
                HasStatistics = leagueDto.Coverage.Fixtures.Statistics,
                HasPlayersStatistics = leagueDto.Coverage.Fixtures.PlayersStatistics
            };
        }
    }
}
