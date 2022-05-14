using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures;
using Infrastructure.ExternalApis.ApiFootball.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.BackgroundJobs.ApiFootballUpdater
{
    public class FixtureUpdater
    {
        private readonly AppDbContext _context;
        private readonly IApiFootballClient _apiClient;
        private readonly FixturesMapper _fixturesMapper;
        private readonly ScoreMapper _scoreMapper;
        private readonly ILogger<FixtureUpdater> _logger;

        public FixtureUpdater(AppDbContext context, IApiFootballClient apiClient, FixturesMapper fixturesMapper, ScoreMapper scoreMapper, ILogger<FixtureUpdater> logger)
        {
            _context = context;
            _apiClient = apiClient;
            _fixturesMapper = fixturesMapper;
            _scoreMapper = scoreMapper;
            _logger = logger;
        }

        public async Task Update()
        {
            //var fixtureDtosFromApi = await DownloadFixturesFromApi();

            var fixtureDtosFromApi = await DownloadFixturesFromApiForLeaguesFromBase();

            var fixtureDtosWithOdds = await SelectFixturesWithOdds(fixtureDtosFromApi);

            var fixturesFromApi = MapFixtureDtosToFixture(fixtureDtosWithOdds);

            var fixturesFromApiWithScore = AddScoreToFixturesFromApi(fixtureDtosWithOdds, fixturesFromApi);

            var fixturesFromBase = await FetchFixturesFromBase(fixturesFromApiWithScore);

            var fixturesToUpdateHandlers = new List<FixturesHandler>();
            var fixturesToAdd = new List<Fixture>();
            SortFixturesForAddingAndUpdate(fixturesFromApiWithScore, fixturesFromBase, fixturesToUpdateHandlers, fixturesToAdd);

            await AddNewFixturesToContext(fixturesToAdd);

            UpdateFixturesWhenDataFromApiHasChanged(fixturesToUpdateHandlers);

            await _context.SaveChangesAsync();

        }

        public async Task<List<FixtureDto>> DownloadFixturesFromApiForLeaguesFromBase()
        {
            var leagueIds = await _context.Fixtures
                .Select(x => x.LeagueId)
                .Distinct()
                .ToListAsync();

            var extLeagueIds = await _context.Leagues
                .Where(x => leagueIds.Contains(x.Id))
                .Select(x => x.ExtLeagueId)
                .ToListAsync();

            var tasks = new List<Task<List<FixtureDto>>>();

            foreach (var extLeagueId in extLeagueIds)
            {
                tasks.Add(_apiClient.DownloadAllFixturesByLeagueIdWithoutMapping(extLeagueId));
            }

            await Task.WhenAll(tasks);

            var fixtureDtos = new List<FixtureDto>();

            foreach (var task in tasks)
            {
                if (task.Result != null)
                    fixtureDtos.AddRange(task.Result);
            }

            return fixtureDtos;
        }

        private void UpdateFixturesWhenDataFromApiHasChanged(List<FixturesHandler> fixturesToUpdateHandlers)
        {
            var fixturesToUpdate = new List<Fixture>();

            foreach (var handler in fixturesToUpdateHandlers)
            {
                var fixtureFromApi = handler.FixtureFromApi;
                var fixtureFromBase = handler.FixtureFromBase;

                if (!fixtureFromApi.Equals(fixtureFromBase))
                {
                    if (fixtureFromApi.Score != null 
                        && (fixtureFromApi.Status is MatchStatus.FT or MatchStatus.AET or MatchStatus.PEN
                                                     && fixtureFromBase.Score == null))
                    {
                        fixtureFromBase.Score = fixtureFromApi.Score;
                        fixtureFromBase.Score.ExtFixtureId = fixtureFromApi.ExtFixtureId;
                        fixtureFromBase.Score.FixtureId = fixtureFromBase.Id;
                    }

                    fixtureFromBase.Elapsed = fixtureFromApi.Elapsed;
                    fixtureFromBase.EventDate = fixtureFromApi.EventDate;
                    fixtureFromBase.FirstHalfStart = fixtureFromApi.FirstHalfStart;
                    fixtureFromBase.Referee = fixtureFromApi.Referee;
                    fixtureFromBase.Status = fixtureFromApi.Status;
                    fixtureFromBase.StatusName = fixtureFromApi.StatusName;
                    fixtureFromBase.Venue = fixtureFromApi.Venue;
                    fixtureFromBase.UpdatedAt = DateTime.UtcNow;

                    fixturesToUpdate.Add(fixtureFromBase);
                }
            }

            _context.Fixtures.UpdateRange(fixturesToUpdate);
            _logger.LogInformation($"Updated {fixturesToUpdate.Count} fixtures");
        }

        private async Task AddNewFixturesToContext(List<Fixture> fixturesToAdd)
        {
            await _context.Fixtures.AddRangeAsync(fixturesToAdd);
            _logger.LogInformation($"Added {fixturesToAdd.Count} new fixtures");
        }

        private static void SortFixturesForAddingAndUpdate(List<Fixture> fixturesFromApi, List<Fixture> fixturesFromBase,
            List<FixturesHandler> fixturesToUpdateHandlers, List<Fixture> fixturesToAdd)
        {
            foreach (var fixtureFromApi in fixturesFromApi)
            {
                var fixtureFromBase = fixturesFromBase
                    .FirstOrDefault(x => x.ExtFixtureId == fixtureFromApi.ExtFixtureId);

                if (fixtureFromBase != null)
                {
                    fixturesToUpdateHandlers.Add(new FixturesHandler
                    {
                        FixtureFromBase = fixtureFromBase,
                        FixtureFromApi = fixtureFromApi
                    });
                }
                else
                {
                    fixturesToAdd.Add(fixtureFromApi);
                }
            }
        }

        private List<Fixture> MapFixtureDtosToFixture(List<FixtureDto> fixtureDtosWithOdds)
        {
            var fixturesFromApi = _fixturesMapper.MapDtosToModels(fixtureDtosWithOdds);
            return fixturesFromApi;
        }

        private async Task<List<FixtureDto>> SelectFixturesWithOdds(List<FixtureDto> fixtureDtos)
        {
            var leaguesWithOdds = await _context.Leagues.ToListAsync();

            var leaguesWithOddsIds = leaguesWithOdds.Select(x => x.ExtLeagueId);

            var fixtureDtosWithOdds = fixtureDtos.Where(x => leaguesWithOddsIds.Contains(x.LeagueId)).ToList();
            return fixtureDtosWithOdds;
        }

        private async Task<List<Fixture>> FetchFixturesFromBase(List<Fixture> fixturesFromApi)
        {
            var extFixtureIds = fixturesFromApi.Select(x => x.ExtFixtureId);

            var fixturesFromBase = await _context.Fixtures.Where(x => extFixtureIds.Contains(x.ExtFixtureId))
                .Include(x => x.Score).ToListAsync();

            return fixturesFromBase;
        }

        private List<Fixture> AddScoreToFixturesFromApi(List<FixtureDto> fixtureDtosWithOdds, List<Fixture> fixturesFromApi)
        {
            var scores = _scoreMapper.MapDtosToModels(fixtureDtosWithOdds);

            foreach (var score in scores)
            {
                if (score == null)
                    continue;

                var fixture = fixturesFromApi.FirstOrDefault(x => x.ExtFixtureId == score.FixtureId);

                if (fixture != null)
                    fixture.Score = score;
            }

            return fixturesFromApi;
        }

        private async Task<List<FixtureDto>> DownloadFixturesFromApi()
        {
            var tasks = new List<Task<List<FixtureDto>>>();

            for (var i = -1; i <= 7; i++)
            {
                tasks.Add(_apiClient.DownloadAllFixturesByDate(DateTime.Today.AddDays(i)));
            }

            await Task.WhenAll(tasks);

            var fixtureDtos = new List<FixtureDto>();

            foreach (var task in tasks)
            {
                if (task.Result != null)
                    fixtureDtos.AddRange(task.Result);
            }

            return fixtureDtos;
        }
    }


    internal class FixturesHandler
    {
        public Fixture FixtureFromBase { get; set; }

        public Fixture FixtureFromApi { get; set; }
    }
}
