using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Enums;
using ApiFootball.BetTypes.GoalsOverUnderType.Generators;
using ApiFootball.BetTypes.WinnerType.Generators;
using ApiFootball.Client;
using ApiFootball.Seeders;
using Bookmaker.Api.Data.Data;
using Bookmaker.ApiFootball.DataInitialization;
using Bookmaker.ApiFootball.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Label = Domain.Entities.Label;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ApiFootballLeaguesService _apiFootballLeaguesService;
        private readonly IApiFootballClient _client;
        private readonly IDataInitialization _dataInitializaion;
        private readonly ApiFootballSeeder _apiFootballSeeder;

        public TestController(AppDbContext context, ApiFootballLeaguesService apiFootballLeaguesService, IApiFootballClient client, IDataInitialization xd, ApiFootballSeeder apiFootballSeeder)
        {
            _context = context;
            _apiFootballLeaguesService = apiFootballLeaguesService;
            _client = client;
            _dataInitializaion = xd;
            _apiFootballSeeder = apiFootballSeeder;
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
            var xsssd = GoalsOverUnderOddValuesGenerator.GoalsOverUnderOddValues();

            var sdsd = new Bet()
            {
                Label = new Label()
                {
                    ExtLabelId = 1
                },
                BetValues = new List<BetValue>()
                {
                    new BetValue()
                    {
                        Value = "Home",
                        Odd = 12
                    },
                    new BetValue()
                    {
                        Value = "Draw",
                        Odd = 12.74m
                    },
                    new BetValue()
                    {
                        Value = "Away",
                        Odd = 0.77m
                    },
                }
            };

            var matchWinner = new MatchWinnerGenerator(sdsd);

            var xd = "2H";
            MatchStatus matchStatus;
            var isLeagueTypeCorrect = Enum.TryParse<MatchStatus>(xd, true, out matchStatus);
            return Ok();
            // TODO: MatchStatus enum conversion 2H -> H2
        }


        public async Task<IActionResult> Download()
        {
            //var seasons = await _client.DownloadAllIResources<SeasonDto>()

            //var leagueDtOs = await _client.DownloadAllIResources<DtoHolder<LeagueDto>, LeagueDto>("/leagues");

            //var xdd = _dataInitializaion.DownloadAllFirstTime<LeagueDTO, League>();

            //var xd = await _client.RequestAsync("/leagues");

            //var xdd = JsonConvert.DeserializeAnonymousType(xd.Content, new {Xd = 10 });

            //var xddd = xdd["leagues"];

            //var xd = await  _client.DownloadAllIResources<DtoHolder<Country>, Country>("/countries");

            //var xd = await _client.DownloadAllCountries();

            //var xd = await _client.DownloadAllLeagues();
            //var leagues = xd.Where(x => x.HasOdds == true && x.CountryCode == "GB").ToList();
            //var leagues = xd.Where(x => x.HasOdds == true).ToList();

            //var teams = await _client.DownloadTeamsByLeagueId(2655);//scotland

            //await _apiFootballSeeder.SeedData();
            //var leagues = await _client.DownloadAllLeagues();
            //await _context.Leagues.AddRangeAsync(leagues);
            //await _context.SaveChangesAsync();
            //var seasons = await _client.DownloadAllSeasons();

            //var xd = await _client.DownloadAllRoundsByLeagueId(2655);

            var fixtures = await _client.DownloadAllFixturesByLeagueId(2655);//scotland

            //await _apiFootballSeeder.SeedData();

            return Ok();
        }
    }
}
