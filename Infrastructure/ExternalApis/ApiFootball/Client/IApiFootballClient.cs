using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.Dtos;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Odds;
using RestSharp;
using FixtureDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures.FixtureDto;

namespace Infrastructure.ExternalApis.ApiFootball.Client
{
    public interface IApiFootballClient
    {
        Task<List<TDto>> DownloadAllIResources<THolder, TDto>(string resourcesUrl)
            where THolder : DtoHolder<TDto>;

        Task<IRestResponse> RequestAsync(string endpoint, Dictionary<string, string> parameters = null, Method method = Method.GET);

        Task<List<Country>> DownloadAllCountries();

        Task<List<Season>> DownloadAllSeasons();

        Task<List<League>> DownloadAllLeagues();

        Task<List<Team>> DownloadTeamsByLeagueId(int extLeagueId);

        Task<List<Label>> DownloadAllLabels();

        Task<List<Round>> DownloadAllRoundsByLeagueId(int extLeagueId);

        Task<List<Fixture>> DownloadAllFixturesByLeagueId(int extLeagueId);

        Task<List<PotentialBet>> DownloadAllBetsByLeagueId(int extLeagueId);
        
        Task<List<Bookie>> DownloadAllBookies();

        Task<List<FixtureDto>> DownloadAllFixturesByDate(DateTime dateTime);

        Task<List<FixtureDto>> DownloadAllFixturesByLeagueIdWithoutMapping(int extLeagueId);

        Task<List<OddDto>> DownloadAllOddsByLeagueId(int extLeagueId);

    }
}