using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Constants;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Models
{
    public class ValidationResponse : Response
    {
        public List<ValidationError> ValidationErrors { get; init; }

        protected ValidationResponse(ModelStateDictionary modelState, bool isSucceeded, Error error, HttpStatusCode httpStatus = HttpStatusCode.OK) : base(isSucceeded, error, httpStatus)
        {
            ValidationErrors = new List<ValidationError>();
            foreach (var key in modelState.Keys)
            {
                var validationError = ValidationErrors
                    .FirstOrDefault(x => x.Field == key);

                if (validationError != null)
                {
                    validationError.Messages.AddRange(modelState[key].Errors.Select(x => x.ErrorMessage));
                }
                else
                {
                    var errorMessages = modelState[key]
                        .Errors.Select(x => x.ErrorMessage).ToList();

                    ValidationErrors.Add(new ValidationError(key, errorMessages));
                }
            }
        }

        protected ValidationResponse(List<ValidationError> validationErrors, bool isSucceeded, Error error, HttpStatusCode httpStatus = HttpStatusCode.OK) : base(isSucceeded, error, httpStatus)
        {
            ValidationErrors = validationErrors;
        }

        public static ValidationResponse Create(ModelStateDictionary modelState)
        {
            return new ValidationResponse(modelState, false,
                Errors.ModelValidatorError);
        }

        public static ValidationResponse Create(List<ValidationError> validationErrors)
        {
            return new ValidationResponse(validationErrors, false,
                Errors.ModelValidatorError);
        }
    }
}
