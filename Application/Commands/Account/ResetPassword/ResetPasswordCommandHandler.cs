using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Models;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Account.ResetPassword;

public class ResetPasswordCommandHandler : BaseCommandHandler, IRequestHandler<ResetPasswordCommand, Response>
{
    private readonly IEmailSenderService _emailSender;

    public ResetPasswordCommandHandler(IDbContext ctx, IUserContextService userCtx, IEmailSenderService emailSender)
        : base(ctx, userCtx)
    {
        _emailSender = emailSender;
    }

    public async Task<Response> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users.FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower().Trim(), cancellationToken);

        if (user == null)
            return Response.Success();

        var resetToken = Guid.NewGuid().ToString();

        user.ResetPasswordToken = resetToken;
        
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        await _emailSender.SendResetPasswordEmail(user.Email, user.UserName, resetToken);

        return Response.Success();
    }
}

