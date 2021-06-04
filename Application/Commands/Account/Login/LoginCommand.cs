using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Commands.Account.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<Response>;

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Password).NotNull();
        }
    }
}
