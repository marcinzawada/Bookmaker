using Bookmaker.ApiFootball.DTOs;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookmaker.ApiFootball.Client
{
    public interface IApiFootballClient
    {
        Task<List<DTO>> DownloadAllIResources<H, DTO>(string resourcesUrl)
            where H : DTOsHolder<DTO>;

        Task<IRestResponse> RequestAsync(string endpoint, Dictionary<string, string> parameters = null, Method method = Method.GET);
    }
}