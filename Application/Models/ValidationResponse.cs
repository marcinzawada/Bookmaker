using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Models
{
    public class ValidationResponse : Response
    {
        public List<ValidationError> ValidationErrors { get; init; }

        protected ValidationResponse(ModelStateDictionary modelState, bool isSucceeded, Error error, HttpStatusCode httpStatus = HttpStatusCode.OK) : base(isSucceeded, error, httpStatus)
        {
            ValidationErrors = (modelState.Keys.SelectMany(key =>
                modelState[key].Errors.Select(e =>
                    new ValidationError(key, e.ErrorMessage))).ToList());
        }

        public static ValidationResponse Create(ModelStateDictionary modelState)
        {
            return new(modelState, false,
                Errors.ModelValidatorError);
        }
    }
}
