using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Response
    {
        public bool IsSucceeded { get; init; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Error Error { get; init; }

        [System.Text.Json.Serialization.JsonIgnore]
        public HttpStatusCode HttpStatus { get; init; }

        protected Response(bool isSucceeded, Error error, HttpStatusCode httpStatus = HttpStatusCode.OK)
        {
            IsSucceeded = isSucceeded;
            Error = error;
            HttpStatus = error?.StatusCode ?? httpStatus;
        }

        public static Response Success(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new(true, null, statusCode);
        }

        public static Response Failure(Error error)
        {
            return new(false, error, HttpStatusCode.BadRequest);
        }
    }
}
