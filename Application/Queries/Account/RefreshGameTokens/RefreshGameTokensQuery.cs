using Application.Models;
using MediatR;

namespace Application.Queries.Account.RefreshTokens
{

    public record AddTokensCommand() : IRequest<Response>;
}
