using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Client
{
    public class ApiFootballClient
    {
        private readonly IConfiguration _configuration;
        private readonly RestClient _restClient;

        public ApiFootballClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/leagues");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "fe7e68095dmsh3ab1bccf87f3dcdp1d3d30jsne245d22c32b8");
            //IRestResponse response = await client.ExecuteAsync(request);
        }

        public void Request(string endpoint, Dictionary<string, string> parameters)
        {
            var request = new RestRequest(Method.GET);
        }
    }
}
