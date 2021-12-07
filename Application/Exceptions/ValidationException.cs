using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public sealed class ValidationException : Exception 
    {
        public ValidationException(List<ValidationError> validationErrors)
            => ValidationErrors = validationErrors;

        public List<ValidationError> ValidationErrors { get; }
    }
}
