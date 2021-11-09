using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Application.Commands.Account.AddTokens
{

    public record AddTokensCommand() : IRequest<Response>;
}
