using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiFootball.DTOs;
using ApiFootball.DTOs.Countries;
using ApiFootball.DTOs.Fixtures.Rounds;
using ApiFootball.DTOs.Labels;
using ApiFootball.DTOs.Odds;
using ApiFootball.DTOs.Seasons;
using ApiFootball.Mappers;
using Domain.Entities;
using Infrastructure.ExtensionMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using BookieDto = ApiFootball.DTOs.Bookies.BookieDto;
using FixtureDto = ApiFootball.DTOs.Fixtures.FixtureDto;
using LeagueDto = ApiFootball.DTOs.Leagues.LeagueDto;
using TeamDto = ApiFootball.DTOs.Teams.TeamDto;

namespace ApiFootball.Client
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

            IRestResponse response = await _restClient.ExecuteAsync(request);
            return response;
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
            throw new Exception("Api doesn't return data, resourceUrl: " +resourcesUrl);
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
                rounds.Add(new RoundDto{Name = roundJson.ToString(), ExtLeagueId = extLeagueId});   
            }
            return _mapper.MapRoundDtosToRounds(rounds);
        }

        public async Task<List<Fixture>> DownloadAllFixturesByLeagueId(int extLeagueId)
        {
            var fixtureDtos = await DownloadAllIResources<DtoHolder<FixtureDto>, FixtureDto>($"/fixtures/league/{extLeagueId}");
            return _mapper.MapFixtureDtosToFixtures(fixtureDtos);
        }

        public async Task<List<Bet>> DownloadAllBetsByLeagueId(int extLeagueId)
        {
            var response = await RequestAsync($"/odds/league/{extLeagueId}");

            var holder = response.Content.Deserialize<DtoContainer<DtoHolder<OddDto>>>().DtoHolder;

            var oddDtos = holder.Resources; 

            if (holder.Paging.TotalPages > 1)
            {
                for (var i = 2; i <= holder.Paging.TotalPages; i++)
                {
                    var nextOdds = await DownloadAllIResources<DtoHolder<OddDto>, OddDto>($"/odds/league/{extLeagueId}?page={i}");
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
    }
}
