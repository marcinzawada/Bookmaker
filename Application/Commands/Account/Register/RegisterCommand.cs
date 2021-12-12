using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Commands.Account.Register
{
    public record RegisterCommand(string Email, string UserName, string Password, string ConfirmPassword) : IRequest<Response>;

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(IDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .CustomAsync(async (email, context, cancellationToken) =>
                {
                    var userWithThisEmailInBase =
                        await dbContext.Users.Where(x =>
                                x.Email.ToLower().Trim() ==
                                email.ToLower().Trim())
                            .ToListAsync(cancellationToken);

                    if (userWithThisEmailInBase.Any())
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(32)
                .CustomAsync(async (userName, context, cancellationToken) =>
                {
                    var userWithThisEmailInBase =
                        await dbContext.Users.Where(x =>
                                x.UserName.ToLower().Trim() ==
                                userName.ToLower().Trim())
                            .ToListAsync(cancellationToken);

                    if (userWithThisEmailInBase.Any())
                    {
                        context.AddFailure("UserName", "That username is taken");
                    }
                });

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]")
                .WithMessage("'{PropertyName}' must contain one or more special characters.")
                .Matches("^[^# ]*$")
                .WithMessage("'{PropertyName}' must not contain the following characters # or spaces.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password).WithMessage("'{PropertyName}' must match 'Password'");
        }
    }
}