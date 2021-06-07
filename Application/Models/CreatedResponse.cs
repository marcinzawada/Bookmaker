using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreatedResponse : Response
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ResourcePath { get; init; }

        protected CreatedResponse(string resourcePath, bool isSucceeded, Error error, HttpStatusCode httpStatus = HttpStatusCode.OK) : base(isSucceeded, error, httpStatus)
        {
            ResourcePath = resourcePath;
        }

        public static CreatedResponse Create(string resourcePath)
        {
            return new CreatedResponse(resourcePath, true, null, HttpStatusCode.Created);
        }
    }
}
