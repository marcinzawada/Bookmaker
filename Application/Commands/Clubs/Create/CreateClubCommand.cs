using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Commands.Clubs.Create
{

    public record CreateClubCommand(string ClubName) : IRequest<Response>;

    public class CreateClubCommandValidator : AbstractValidator<CreateClubCommand>
    {
        public CreateClubCommandValidator()
        {
            RuleFor(x => x.ClubName)
                .NotNull().NotEmpty().MinimumLength(1).MaximumLength(64);
        }
    }


}
