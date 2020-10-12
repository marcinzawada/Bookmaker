using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookmaker.ApiFootball.Responses;
using Bookmaker.ApiFootball.Responses.Leagues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Bookmaker.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public  IRestResponse Get()
        {
            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/leagues");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "fe7e68095dmsh3ab1bccf87f3dcdp1d3d30jsne245d22c32b8");
            IRestResponse response = client.Execute(request);

            var xd = JsonConvert.DeserializeObject<AllLeaguesResponseContainer>(response.Content);
            return response;
        }
    }
}
