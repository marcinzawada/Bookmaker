using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Commands.Clubs.Leave
{

    public record LeaveClubCommand(int ClubId) : IRequest<Response>;

    public class LeaveClubCommandValidator : AbstractValidator<LeaveClubCommand>
    {
        public LeaveClubCommandValidator()
        {
            RuleFor(x => x.ClubId)
                .NotEmpty().NotNull().GreaterThanOrEqualTo(1);
        }
    }

}
