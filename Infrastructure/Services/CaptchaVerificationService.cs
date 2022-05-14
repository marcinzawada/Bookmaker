using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Services
{
    public class CaptchaVerificationService : ICaptchaVerificationService
    {
        private readonly IConfiguration _configuration;

        public CaptchaVerificationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> IsCaptchaValid(string captchaToken)
        {
            var serverKey = _configuration["Recaptcha:ServerKey"];

            const string googleVerificationUrl = "https://www.google.com/recaptcha/api/siteverify";

            using var client = new HttpClient();

            var resp = await client.PostAsync($"{googleVerificationUrl}?secret={serverKey}&response={captchaToken}", null);

            if (resp.StatusCode != HttpStatusCode.OK)
                return false;

            var responseStr= await resp.Content.ReadAsStringAsync();
            dynamic json = JObject.Parse(responseStr);

            return json.success == "true" && json.score > 0.5m;
        }
    }
}
