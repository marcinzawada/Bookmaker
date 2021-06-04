using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Repositories;
using FluentValidation;
using MediatR;


namespace Application.Commands.Account.Register
{
    public record RegisterCommand(string Email, string Password, string ConfirmPassword) : IRequest<Response>;

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .CustomAsync(async (email, context, cancellationToken) =>
                {
                    var userWithThisEmailInBase = 
                        await userRepository.FindAsync(x => 
                            x.Email == email, cancellationToken);
                    
                    if (userWithThisEmailInBase.Any())
                    {
                        context.AddFailure("Email", "That email is taken");
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