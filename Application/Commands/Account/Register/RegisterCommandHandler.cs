using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace Application.Commands.Account.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response>
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IDbContext _context;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly ICaptchaVerificationService _captcha;

        public RegisterCommandHandler(IPasswordHasher<User> passwordHasher, IDbContext context, IJwtGenerator jwtGenerator, ICaptchaVerificationService captcha)
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _jwtGenerator = jwtGenerator;
            _captcha = captcha;
        }

        public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var recaptchaResult = await _captcha.IsCaptchaValid(request.RecaptchaToken);

            if (recaptchaResult == false)
                return Response.Failure(Errors.Forbidden());

            var newUser = new User()
            {
                Email = request.Email.ToLower().Trim(),
                UserName = request.UserName.Trim()
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, request.Password);
            newUser.PasswordHash = hashedPassword;

            await _context.Users.AddAsync(newUser, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var token = _jwtGenerator.Generate(newUser);

            var authDto = new AuthDto
            {
                Id = newUser.Id,
                UserName = newUser.UserName,
                Token = token,
                GameTokens = newUser.GameTokens
            };

            return Result<AuthDto>.Create(authDto);
        }
    }
}
