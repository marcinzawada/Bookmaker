using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Constants
{
    public static class ErrorMessages
    {
        public const string InvalidCredentialsMessage = "Invalid email or password";
        public const string EntityNotFoundMessage = "Entity not found";
        public const string InvalidBetDataMessage = "Invalid bet data";
        public const string Forbidden = "Forbidden";
        public const string InvalidUserToAddToClub = "Can't invite youreslf";
    }
}
