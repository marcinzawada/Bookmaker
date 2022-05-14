using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Account.Login;
using Application.Common.Constants;
using Application.Common.Interfaces;
using Application.Common.JWT;
using Application.Models;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Account.ChangePassword;

public class ChangePasswordCommandHandler : BaseCommandHandler, IRequestHandler<ChangePasswordCommand, Response>
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IJwtGenerator _jwtGenerator;

    public ChangePasswordCommandHandler(IDbContext context, IUserContextService userContextService, IPasswordHasher<User> passwordHasher, IJwtGenerator jwtGenerator) : base(context, userContextService)
    {
        _passwordHasher = passwordHasher;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<Response> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.ResetPasswordToken == request.ResetToken.ToLower().Trim(), cancellationToken);

        if (user is null)
            return Response.Failure(Errors.Forbidden());

        var hashedPassword = _passwordHasher.HashPassword(user, request.NewPassword);
        user.PasswordHash = hashedPassword;
        user.ResetPasswordToken = null;

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        return Response.Success();
    }
}
