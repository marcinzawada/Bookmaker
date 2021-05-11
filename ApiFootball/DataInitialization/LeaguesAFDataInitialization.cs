using Bookmaker.Api.Data.Data;
using Bookmaker.ApiFootball.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFootball.Client;

namespace Bookmaker.ApiFootball.DataInitialization
{
    public class LeaguesAfDataInitialization : BaseAfDataInitialization
    {
        private readonly ILogger<LeaguesAfDataInitialization> _logger;

        public LeaguesAfDataInitialization(ILogger<LeaguesAfDataInitialization> logger,
            AppDbContext context, IApiFootballClient client) : base(context, client)
        {
            _logger = logger;
        }

        //public async Task<List<Models.League>> DownloadAllLeaguesFirstTime()
        //{
        //    var leaguesInBase = await _context.Leagues.ToListAsync();
        //    if (leaguesInBase.Count != 0)
        //        return leaguesInBase;

        //    List<DTOs.Leagues.League> leaguesDTOs = await DownloadAllLeaguesFromApi();

        //    List<Models.League> leagues = new List<Models.League>();

        //    foreach (var leagueDTO in leaguesDTOs)
        //    {
        //        var leagueType = ParseLeagueType(leagueDTO);

        //        var isSeasonStartCorrect = ParseDate(leagueDTO.SeasonStart, out DateTime seasonStart);
        //        seasonStart = MarkDateSeasonIncorrect(isSeasonStartCorrect, seasonStart, leagueDTO);

        //        var isSeasonEndCorrect = ParseDate(leagueDTO.SeasonStart, out DateTime seasonEnd);
        //        seasonEnd = MarkDateSeasonIncorrect(isSeasonEndCorrect, seasonEnd, leagueDTO);

        //        leagues = AddNewLeague(leagues, leagueDTO, leagueType, seasonStart, seasonEnd);
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

        //private LeagueType ParseLeagueType(DTOs.Leagues.League leagueDTO)
        //{
        //    var isLeagueTypeCorrect = Enum.TryParse<LeagueType>(leagueDTO.Type, true, out LeagueType leagueType);
        //    if (!isLeagueTypeCorrect)
        //    {
        //        leagueType = LeagueType.OTHER;
        //        _logger.LogError("Invalid LeagueType from api: " +
        //            leagueDTO.Type + "ExtLeagueId: " + leagueDTO.Type);
        //    }
        //    return leagueType;
        //}

        //private bool ParseDate(string date, out DateTime parsedDate)
        //{
        //    return DateTime.TryParseExact(
        //        date, "yyyy-MM-dd",
        //        System.Globalization.CultureInfo.InvariantCulture,
        //        System.Globalization.DateTimeStyles.None, out parsedDate);
        //}

        //private DateTime MarkDateSeasonIncorrect(bool dateIsCorrect, DateTime date, DTOs.Leagues.League leagueDTO)
        //{
        //    if (dateIsCorrect)
        //        return date;
        //    _logger.LogWarning("Invalid season start date. ExtLeagueId: " + leagueDTO.ExtLeagueId);
        //    return date.AddYears(-30);
        //}

        //private List<Models.League> AddNewLeague(List<Models.League> leagues, DTOs.Leagues.League leagueDTO,
        //    LeagueType leagueType, DateTime seasonStart, DateTime seasonEnd)
        //{
        //    leagues.Add(new Models.League
        //    {
        //        Name = leagueDTO.Name,
        //        Type = leagueType,
        //        Country = leagueDTO.Country,
        //        CountryCode = leagueDTO.CountryCode,
        //        Season = leagueDTO.Season,
        //        SeasonStart = seasonStart,
        //        SeasonEnd = seasonEnd,
        //        Logo = leagueDTO.Logo,
        //        Flag = leagueDTO.Flag,
        //        HasStandings = leagueDTO.Standings,
        //        IsCurrent = leagueDTO.IsCurrent,
        //        HasCoverageStandings = leagueDTO.Coverage.CoverageStandings,
        //        HasPlayers = leagueDTO.Coverage.Players,
        //        HasTopScorers = leagueDTO.Coverage.TopScorers,
        //        HasPredictions = leagueDTO.Coverage.Predictions,
        //        HasOdds = leagueDTO.Coverage.Odds,
        //        HasEvents = leagueDTO.Coverage.Fixtures.Events,
        //        HasLineups = leagueDTO.Coverage.Fixtures.Lineups,
        //        HasStatistics = leagueDTO.Coverage.Fixtures.Statistics,
        //        HasPlayersStatistics = leagueDTO.Coverage.Fixtures.PlayersStatistics
        //    });
        //    return leagues;
        //}
    }
}
