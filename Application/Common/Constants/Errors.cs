using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Common.Constants
{
    public static class Errors
    {
        public static Error ModelValidatorError => new(ErrorCodes.ValidationError, ValidatorMessages.ModelValidatorMessage,
            HttpStatusCode.UnprocessableEntity);

        public static Error InvalidCredentials => new(ErrorCodes.InvalidCredentials,
            ErrorMessages.InvalidCredentialsMessage);

        public static Error EntityNotFound<T>()
        {
            return new(ErrorCodes.EntityNotFound, ErrorMessages.EntityNotFoundMessage.Replace("Entity", typeof(T).Name), HttpStatusCode.NotFound);
        }

        public static Error EntityNotFound()
        {
            return new(ErrorCodes.EntityNotFound, ErrorMessages.EntityNotFoundMessage, HttpStatusCode.NotFound);
        }
    }
}
