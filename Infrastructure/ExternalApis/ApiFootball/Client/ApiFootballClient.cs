using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.ExtensionMethods;
using Infrastructure.ExternalApis.ApiFootball.Dtos;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Countries;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures.Rounds;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Labels;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Odds;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Seasons;
using Infrastructure.ExternalApis.ApiFootball.Mappers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using BookieDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Bookies.BookieDto;
using FixtureDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures.FixtureDto;
using LeagueDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Leagues.LeagueDto;
using TeamDto = Infrastructure.ExternalApis.ApiFootball.Dtos.Teams.TeamDto;

namespace Infrastructure.ExternalApis.ApiFootball.Client
{
    public class ApiFootballClient : IApiFootballClient
    {
        private readonly RestClient _restClient;
        private readonly ILogger<ApiFootballClient> _logger;
        private readonly string _host;
        private readonly string _key;
        private readonly ApiFootballMapper _mapper;

        public ApiFootballClient(IConfiguration configuration, ILogger<ApiFootballClient> logger, ApiFootballMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _host = configuration.GetSection("ApiFootballCredential").GetSection("x-rapidapi-host").Value;
            _key = configuration.GetSection("ApiFootballCredential").GetSection("x-rapidapi-key").Value;
            var baseUrl = configuration.GetSection("ApiFootballCredential").GetSection("BaseUrl").Value;
            _restClient = new RestClient(baseUrl);

        }

        public async Task<IRestResponse> RequestAsync(string endpoint,
            Dictionary<string, string> parameters = null, Method method = Method.GET)
        {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("x-rapidapi-host", _host);
            request.AddHeader("x-rapidapi-key", _key);

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    request.AddParameter(p.Key, p.Value);
                }
            }

            var response = await _restClient.ExecuteAsync(request);

            if (response.IsSuccessful)
                return response;

            _logger.LogCritical($"ApiFootball return invalid response, endpoint: {endpoint}");
            throw new Exception($"ApiFootball return invalid response, endpoint: {endpoint}");

        }

        public async Task<List<TDto>> DownloadAllIResources<THolder, TDto>(string resourcesUrl)
            where THolder : DtoHolder<TDto>
        {
            var response = await RequestAsync(resourcesUrl);

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var container =
                JsonConvert.DeserializeObject<DtoContainer<THolder>>(response.Content, serializerSettings);

            if (container != null)
                return container.DtoHolder.Resources;

            _logger.LogError("Api doesn't return data, resourceUrl: " + resourcesUrl);
            throw new Exception("Api doesn't return data, resourceUrl: " + resourcesUrl);
        }

        public async Task<List<Country>> DownloadAllCountries()
        {
            var countryDtos = await DownloadAllIResources<DtoHolder<CountryDto>, CountryDto>("/countries");
            return _mapper.MapCountryDtosToCountries(countryDtos);
        }

        public async Task<List<Season>> DownloadAllSeasons()
        {
            var seasonDtos = await DownloadAllIResources<DtoHolder<SeasonDto>, SeasonDto>("/seasons");
            return _mapper.MapSeasonDtosToSeasons(seasonDtos);
        }

        public async Task<List<League>> DownloadAllLeagues()
        {
            var leagueDtos = await DownloadAllIResources<DtoHolder<LeagueDto>, LeagueDto>("/leagues");
            return _mapper.MapLeagueDtosToLeagues(leagueDtos);
        }

        public async Task<List<Team>> DownloadTeamsByLeagueId(int extLeagueId)
        {
            var teamDtos = await DownloadAllIResources<DtoHolder<TeamDto>, TeamDto>($"/teams/league/{extLeagueId}");
            return _mapper.MapLeagueDtosToLeagues(teamDtos, extLeagueId);
        }

        public async Task<List<Label>> DownloadAllLabels()
        {
            var labelDtos = await DownloadAllIResources<DtoHolder<LabelDto>, LabelDto>("/odds/labels");
            return _mapper.MapLabelDtosToLabels(labelDtos);
        }

        public async Task<List<Round>> DownloadAllRoundsByLeagueId(int extLeagueId)
        {
            var response = await RequestAsync($"fixtures/rounds/{extLeagueId}");
            var json = JObject.Parse(response.Content);
            var roundJsons = json["api"]["fixtures"].ToList();
            var rounds = new List<RoundDto>();
            foreach (var roundJson in roundJsons)
            {
                rounds.Add(new RoundDto { Name = roundJson.ToString(), ExtLeagueId = extLeagueId });
            }
            return _mapper.MapRoundDtosToRounds(rounds);
        }

        public async Task<List<Fixture>> DownloadAllFixturesByLeagueId(int extLeagueId)
        {
            var fixtureDtos = await DownloadAllIResources<DtoHolder<FixtureDto>, FixtureDto>($"/fixtures/league/{extLeagueId}");
            return _mapper.MapFixtureDtosToFixtures(fixtureDtos);
        }

        public async Task<List<PotentialBet>> DownloadAllBetsByLeagueId(int extLeagueId)
        {
            var response = await RequestAsync($"/odds/league/{extLeagueId}/bookmaker/8");

            var holder = response.Content.Deserialize<DtoContainer<DtoHolder<OddDto>>>().DtoHolder;

            var oddDtos = holder.Resources;

            if (holder.Paging.TotalPages > 1)
            {
                for (var i = 2; i <= holder.Paging.TotalPages; i++)
                {
                    var nextOdds = await DownloadAllIResources<DtoHolder<OddDto>, OddDto>($"/odds/league/{extLeagueId}/bookmaker/8?page={i}");
                    oddDtos.AddRange(nextOdds);
                }
            }

            var bets = _mapper.MapOddDtosToBets(oddDtos);

            return bets;
        }

        public async Task<List<Bookie>> DownloadAllBookies()
        {
            var bookieDtos = await DownloadAllIResources<DtoHolder<BookieDto>, BookieDto>("/odds/bookmakers");
            return _mapper.MapBookieDtosToBookies(bookieDtos);
        }

        public async Task<List<FixtureDto>> DownloadAllFixturesByDate(DateTime dateTime)
        {
            var date = dateTime.ToString("yyyy-MM-dd");

            var response = await RequestAsync($"/fixtures/date/{date}");

            return DeserializeObjectFromJson<FixtureDto>(response, "fixtures");
        }

        public async Task<List<FixtureDto>> DownloadAllFixturesByLeagueIdWithoutMapping(int extLeagueId)
        {
            var response = await RequestAsync($"/fixtures/league/{extLeagueId}");
            return DeserializeObjectFromJson<FixtureDto>(response, "fixtures");
        }

        public async Task<List<OddDto>> DownloadAllOddsByLeagueId(int extLeagueId)
        {
            var response = await RequestAsync($"/odds/league/{extLeagueId}/bookmaker/8");

            var oddDtos = DeserializeObjectFromJson<OddDto>(response, "odds");

            var totalPageJson = JObject.Parse(response.Content)["api"]?["paging"]?["total"];

            var totalPageIsCorrect = int.TryParse(totalPageJson?.ToString(), out var totalPage);

            if (totalPageIsCorrect && totalPage > 1)
            {
                var tasks = new List<Task<IRestResponse>>();
                for (var i = 2; i <= totalPage; i++)
                {
                    tasks.Add(RequestAsync($"/odds/league/{extLeagueId}/bookmaker/8?page={i}"));
                }

                await Task.WhenAll(tasks);

                foreach (var task in tasks)
                {
                    if (task.Result != null)
                    {
                        var dtos = DeserializeObjectFromJson<OddDto>(task.Result, "odds");
                        oddDtos.AddRange(dtos);
                    }
                }
            }

            return oddDtos;
        }

        public List<T> DeserializeObjectFromJson<T>(IRestResponse apiResponse, string resourceName)
        {
            var jsonObjects = JObject.Parse(apiResponse.Content)["api"]?[resourceName]!.ToList();

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonArray = new JArray(jsonObjects);

            var dtos = JsonConvert.DeserializeObject<List<T>>(jsonArray.ToString(), serializerSettings);

            return dtos;
        }
    }
}
