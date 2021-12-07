using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Account.Login
{
    public class AuthDto
    {
        public int Id { get; init; }

        public string Token { get; init; }

        public string UserName { get; init; }
    }
}
