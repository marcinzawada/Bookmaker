using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Infrastructure.ExtensionMethods
{
    public static class DeserializeExtensions
    {
        private static readonly JsonSerializerSettings DefaultSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json, DefaultSerializerSettings);
        }
    }
}
