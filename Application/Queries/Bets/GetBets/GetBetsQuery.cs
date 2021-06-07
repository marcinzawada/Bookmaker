using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Queries.Bets.GetBets
{
    public record GetBetsQuery(int OddId) : IRequest<Response>;

    public class GetBetsQueryValidator : AbstractValidator<GetBetsQuery>
    {
        public GetBetsQueryValidator()
        {
            RuleFor(x => x.OddId)
                .NotEmpty().NotNull().GreaterThanOrEqualTo(1);
        }
    }



}
