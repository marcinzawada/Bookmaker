using Bookmaker.ApiFootball.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Client
{
    public class ApiFootballClient : IApiFootballClient
    {
        private readonly RestClient _restClient;
        private readonly string _host;
        private readonly string _key;

        public ApiFootballClient(IConfiguration configuration)
        {
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

        public async Task<List<DTO>> DownloadAllIResources<H, DTO>(string resourcesUrl) where H : DTOsHolder<DTO>
        {
            var response = await this.RequestAsync(resourcesUrl);

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var container =
                JsonConvert.DeserializeObject<DTOsContainer<H>>(response.Content,
                    serializerSettings);

            return container.DTOsHolder.Resources;
        }
    }
}
