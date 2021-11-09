using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Queries.Clubs.Get
{

    public record GetClubQuery(int ClubId) : IRequest<Response>;

    public class GetClubQueryValidator : AbstractValidator<GetClubQuery>
    {
        public GetClubQueryValidator()
        {
            RuleFor(x => x.ClubId)
                .NotNull().NotEmpty().GreaterThanOrEqualTo(1);
        }
    }

}
