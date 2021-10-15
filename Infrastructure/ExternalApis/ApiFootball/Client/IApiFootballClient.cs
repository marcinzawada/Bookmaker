using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.Dtos;
using RestSharp;

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

        Task<List<Bet>> DownloadAllBetsByLeagueId(int extLeagueId);
        
        Task<List<Bookie>> DownloadAllBookies();
    }
}