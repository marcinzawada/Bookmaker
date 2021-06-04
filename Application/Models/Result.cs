using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Result<T> : Response
    {
        public T Content { get; init; }

        protected Result(T content, bool isSucceeded, Error error, HttpStatusCode httpStatus = HttpStatusCode.OK) : base(isSucceeded, error, httpStatus)
        {
            Content = content;
        }

        public static Result<T> Create(T content, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new(content, true, null, statusCode);
        }
    }
}
