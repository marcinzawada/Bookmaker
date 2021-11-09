using System;
using System.Linq;
using Application.Commands.Clubs.Create;
using Application.Common.Interfaces;
using Application.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Clubs.AddUser
{

    public record AddUserToClubCommand(string UserEmail, int ClubId) : IRequest<Response>;

    public class AddUserToClubCommandValidator : AbstractValidator<AddUserToClubCommand>
    {
        public AddUserToClubCommandValidator(IDbContext dbContext)
        {
            RuleFor(x => x.UserEmail)
                .NotNull().NotEmpty().EmailAddress();

            RuleFor(x => x.ClubId)
                .NotNull().NotEmpty().GreaterThanOrEqualTo(1);

        }
    }


}
