using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Client;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Odds;
using Infrastructure.ExternalApis.ApiFootball.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FixtureDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures.FixtureDto;

namespace Infrastructure.BackgroundJobs.ApiFootballUpdater
{
    public class BetsUpdater
    {
        private readonly AppDbContext _context;
        private readonly IApiFootballClient _apiClient;
        private readonly OddToBetMapper _oddToBetMapper;
        private readonly ILogger<BetsUpdater> _logger;

        public BetsUpdater(AppDbContext appDbContext, IApiFootballClient client, OddToBetMapper oddToBetMapper, ILogger<BetsUpdater> logger)
        {
            _context = appDbContext;
            _apiClient = client;
            _oddToBetMapper = oddToBetMapper;
            _logger = logger;
        }

        public async Task Update()
        {
            var extLeagueIds = await GetExtLeagueIdsFromBase();

            var oddDtos = await DownloadOddsFromApi(extLeagueIds);

            var betsFromApi = MapOddsToBets(oddDtos);

            var betsFromBase = await FetchBetsFromBase();

            var newBetsToAdd = await AddNewBetsToContext(betsFromApi, betsFromBase);

            var betsFromApiThatAreInBase = betsFromApi.Except(newBetsToAdd).ToList();

            await UpdateBets(betsFromApiThatAreInBase, betsFromBase);

            await _context.SaveChangesAsync();
        }

        private async Task<List<int>> GetExtLeagueIdsFromBase()
        {
            var leagueIds = await _context.Fixtures
                .Select(x => x.LeagueId)
                .Distinct()
                .ToListAsync();

            var extLeagueIds = await _context.Leagues
                .Where(x => leagueIds.Contains(x.Id))
                .Select(x => x.ExtLeagueId)
                .ToListAsync();
            return extLeagueIds;
        }

        private async Task<List<OddDto>> DownloadOddsFromApi(List<int> extLeagueIds)
        {
            var tasks = new List<Task<List<OddDto>>>();

            foreach (var extLeagueId in extLeagueIds)
            {
                tasks.Add(_apiClient.DownloadAllOddsByLeagueId(extLeagueId));
            }

            await Task.WhenAll(tasks);

            var oddDtos = new List<OddDto>();

            foreach (var task in tasks)
            {
                if (task.Result != null)
                    oddDtos.AddRange(task.Result);
            }

            return oddDtos;
        }

        private List<PotentialBet> MapOddsToBets(List<OddDto> oddDtos)
        {
            var betsFromApi = _oddToBetMapper.MapOddDtosToBets(oddDtos);
            return betsFromApi;
        }

        private async Task<List<PotentialBet>> FetchBetsFromBase()
        {
            var betsFromBase = await _context
                .PotentialBets.AsNoTracking()
                .Include(x => x.BetValues)
                .ToListAsync();
            return betsFromBase;
        }

        private async Task<List<PotentialBet>> AddNewBetsToContext(List<PotentialBet> betsFromApi, List<PotentialBet> betsFromBase)
        {
            var newBetsToAdd = betsFromApi.Except(betsFromBase).ToList();

            await _context.PotentialBets.AddRangeAsync(newBetsToAdd);
            return newBetsToAdd;
        }

        private async Task UpdateBets(List<PotentialBet> betsFromApiThatAreInBase, List<PotentialBet> betsFromBase)
        {
            var newBetValuesToAdd = new List<BetValue>();

            foreach (var bet in betsFromApiThatAreInBase)
            {
                var betFromBase = betsFromBase.FirstOrDefault(x => x.Equals(bet));

                if (betFromBase == null)
                {
                    _logger.LogError($"Missed bet in base for FixtureId: {bet.FixtureId}," +
                                     $" LabelId: {bet.LabelId}, BookieId: {bet.BookieId}, LeagueId: {bet.LeagueId}");

                    continue;
                }

                var betId = betFromBase.Id;
                bet.Id = betId;

                var betValues = bet.BetValues
                    .Where(x => !betFromBase.BetValues.Any(y => y.Equals(x))).ToList();

                foreach (var betValue in betValues)
                {
                    betValue.BetId = betId;
                    newBetValuesToAdd.Add(betValue);
                }

                betsFromBase.Remove(betFromBase);
            }

            await _context.BetValues.AddRangeAsync(newBetValuesToAdd);
        }

    }
}
