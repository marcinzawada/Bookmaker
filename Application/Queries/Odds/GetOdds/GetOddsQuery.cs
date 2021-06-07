using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Queries.Odds.GetOdds
{
    public record GetOddsQuery(int LeagueId) : IRequest<Response>;

    public class GetOddsQueryValidator : AbstractValidator<GetOddsQuery>
    {
        public GetOddsQueryValidator()
        {
            RuleFor(x => x.LeagueId).NotNull().GreaterThanOrEqualTo(1);
        }
    }
}
