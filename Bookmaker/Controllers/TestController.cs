using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bookmaker.Api.Data.Data;
using Bookmaker.Api.Data.Data.Enums;
using Bookmaker.ApiFootball.Client;
using Bookmaker.ApiFootball.DataInitialization;
using Bookmaker.ApiFootball.DTOs;
using Bookmaker.ApiFootball.DTOs.Leagues;
using Bookmaker.ApiFootball.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace Bookmaker.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ApiFootballLeaguesService _apiFootballLeaguesService;
        private readonly IApiFootballClient _client;
        private readonly IDataInitialization _dataInitializaion;

        public TestController(AppDbContext context, ApiFootballLeaguesService apiFootballLeaguesService, IApiFootballClient client, IDataInitialization xd)
        {
            _context = context;
            _apiFootballLeaguesService = apiFootballLeaguesService;
            _client = client;
            _dataInitializaion = xd;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //await _apiFootballLeaguesService.DownloadAllLeaguesFirstTime();
            //var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/leagues");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
            //request.AddHeader("x-rapidapi-key", "fe7e68095dmsh3ab1bccf87f3dcdp1d3d30jsne245d22c32b8");
            //IRestResponse response = await client.ExecuteAsync(request);

            //var leaguesContainer = JsonConvert.DeserializeObject<ResponseContainer<LeaguesResponseHolder>>(response.Content);

            //var leaguesResponse = leaguesContainer.Content.Leagues;

            //List<League> leagues = new List<League>();

            //foreach (var leagueResponse in leaguesResponse)
            //{
            //    LeagueType leagueType;
            //    var isLeagueTypeCorrect = Enum.TryParse<LeagueType>(leagueResponse.Type, true, out leagueType);
            //    if (!isLeagueTypeCorrect)
            //    {
            //        leagueType = LeagueType.OTHER;
            //        // TODO: log it
            //    }
            //    DateTime seasonStart;
            //    DateTime seasonEnd;

            //    var isSeasonStartCorrect = DateTime.TryParseExact(
            //        leagueResponse.SeasonStart, "yyyy-MM-dd",
            //        System.Globalization.CultureInfo.InvariantCulture,
            //        System.Globalization.DateTimeStyles.None, out seasonStart);

            //    var isSeasonEndCorrect = DateTime.TryParseExact(
            //        leagueResponse.SeasonEnd, "yyyy-MM-dd",
            //        System.Globalization.CultureInfo.InvariantCulture,
            //        System.Globalization.DateTimeStyles.None, out seasonEnd);

            //    if (!isSeasonStartCorrect)
            //    {
            //        seasonStart = DateTime.Now.AddYears(-30);
            //        // TODO: log it
            //    }

            //    if (!isSeasonStartCorrect)
            //    {
            //        seasonStart = DateTime.Now.AddYears(-20);
            //        // TODO: log it
            //    }

            //    leagues.Add(new League
            //    {
            //        Name = leagueResponse.Name,
            //        Type = leagueType,
            //        Country = leagueResponse.Country,
            //        CountryCode = leagueResponse.CountryCode,
            //        Season = leagueResponse.Season,
            //        SeasonStart = seasonStart,
            //        SeasonEnd = seasonEnd,
            //        Logo = leagueResponse.Logo,
            //        Flag = leagueResponse.Flag,
            //        HasStandings = leagueResponse.Standings,
            //        IsCurrent = leagueResponse.IsCurrent,
            //        HasCoverageStandings = leagueResponse.Coverage.CoverageStandings,
            //        HasPlayers = leagueResponse.Coverage.Players,
            //        HasTopScorers = leagueResponse.Coverage.TopScorers,
            //        HasPredictions = leagueResponse.Coverage.Predictions,
            //        HasOdds = leagueResponse.Coverage.Odds,
            //        HasEvents = leagueResponse.Coverage.Fixtures.Events,
            //        HasLineups = leagueResponse.Coverage.Fixtures.Lineups,
            //        HasStatistics = leagueResponse.Coverage.Fixtures.Statistics,
            //        HasPlayersStatistics = leagueResponse.Coverage.Fixtures.PlayersStatistics
            //    });
            //}

            //await _context.Leagues.AddRangeAsync(leagues);
            //await _context.SaveChangesAsync();

            return Ok();
        }


        public async Task<IActionResult> Odds()
        {
            var activeLeaguesWithOdds = await _context.Leagues.Where(x => x.IsCurrent &&
                x.SeasonEnd > DateTime.Now.AddDays(1) &&
                x.SeasonStart < DateTime.Now).Take(2).ToListAsync();

            return Ok();
        }

        public IActionResult Test()
        {
            var xd = "2H";
            MatchStatus matchStatus;
            var isLeagueTypeCorrect = Enum.TryParse<MatchStatus>(xd, true, out matchStatus);
            return Ok();
            // TODO: MatchStatus enum conversion 2H -> H2
        }

        //public async Task<IActionResult> Xd()
        //{
        //    var xd = await _client.DownloadAllIResources<LeaguesDTOHolder>("/leagues");

        //    var xxddd = xd.DTOsHolder.Leagues;

        //    return Ok();
        //}

        public async Task<IActionResult> Dupa()
        {
            var leagueDTOs = await _client.DownloadAllIResources<DTOsHolder<LeagueDTO>, LeagueDTO>("/leagues");

            //var xdd = _dataInitializaion.DownloadAllFirstTime<LeagueDTO, League>();

            //var xd = await _client.RequestAsync("/leagues");

            //var xdd = JsonConvert.DeserializeAnonymousType(xd.Content, new {Xd = 10 });

            //var xddd = xdd["leagues"];

            return Ok();
        }
    }
}
