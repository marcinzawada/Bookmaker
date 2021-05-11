using Api.Data.Models;
using Bookmaker.Api.Data.Data;
using Bookmaker.ApiFootball.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Enums;
using ApiFootball.Client;
using ApiFootball.DTOs.Leagues;

namespace Bookmaker.ApiFootball.Services
{
    public class ApiFootballLeaguesService : ApiFootballBaseService
    {
        private readonly ILogger<ApiFootballLeaguesService> _logger;

        public ApiFootballLeaguesService(ILogger<ApiFootballLeaguesService> logger,
            AppDbContext context, IApiFootballClient client) : base(context, client)
        {
            _logger = logger;
        }

        //public async Task<List<Models.League>> DownloadAllLeaguesFirstTime()
        //{
        //    var leaguesInBase = await _context.Leagues.ToListAsync();
        //    if (leaguesInBase.Count != 0)
        //        return leaguesInBase;

        //    //List<DTOs.Leagues.League> leaguesDTOs = await DownloadAllLeaguesFromApi();

        //    List<Models.League> leagues = new List<Models.League>();

        //    foreach (var leagueDTO in leaguesDTOs)
        //    {
        //        var leagueType = ParseLeagueType(leagueDTO);

        //        var isSeasonStartCorrect = ParseDate(leagueDTO.SeasonStart, out DateTime seasonStart);
        //        seasonStart = MarkDateSeasonIncorrect(isSeasonStartCorrect, seasonStart, leagueDTO);

        //        var isSeasonEndCorrect = ParseDate(leagueDTO.SeasonStart, out DateTime seasonEnd);
        //        seasonEnd = MarkDateSeasonIncorrect(isSeasonEndCorrect, seasonEnd, leagueDTO);

        //        AddNewLeague(leagues, leagueDTO, leagueType, seasonStart, seasonEnd);
        //    }

        //    await _context.Leagues.AddRangeAsync(leagues);
        //    await _context.SaveChangesAsync();

        //    return leaguesInBase;
        //}

        //private async Task<List<DTOs.Leagues.League>> DownloadAllLeaguesFromApi()
        //{
        //    var response = await _client.RequestAsync("/leagues");

        //    var leaguesContainer = JsonConvert.DeserializeObject<DTOsContainer<LeaguesDTOHolder>>(response.Content);

        //    var leaguesDTOs = leaguesContainer.DTOsHolder.Leagues;
        //    return leaguesDTOs;
        //}

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

        private bool ParseDate(string date, out DateTime parsedDate)
        {
            return DateTime.TryParseExact(
                date, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out parsedDate);
        }

        private DateTime MarkDateSeasonIncorrect(bool dateIsCorrect, DateTime date, LeagueDto leagueDto)
        {
            if (dateIsCorrect)
                return date;
            _logger.LogWarning("Invalid season start date. ExtLeagueId: " + leagueDto.LeagueId);
            return date.AddYears(-30);
        }

        private static void AddNewLeague(List<League> leagues, LeagueDto leagueDto,
            LeagueType leagueType, DateTime seasonStart, DateTime seasonEnd)
        {
            leagues.Add(new League
            {
                Name = leagueDto.Name,
                Type = leagueType,
                //Country = leagueDTO.Country,
                CountryCode = leagueDto.CountryCode,
                //Season = leagueDTO.Season,
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
            });
        }
    }
}

