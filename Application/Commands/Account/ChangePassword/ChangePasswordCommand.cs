using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Commands.Account.ChangePassword;

public record ChangePasswordCommand(string ResetToken, string NewPassword) : IRequest<Response>;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.NewPassword).MinimumLength(8);
        RuleFor(x => x.ResetToken).NotNull();
    }
}