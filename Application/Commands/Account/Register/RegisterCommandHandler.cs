using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Account.Login;
using Application.Common.Interfaces;
using Application.Common.JWT;
using Application.Models;
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

        public RegisterCommandHandler(IPasswordHasher<User> passwordHasher, IDbContext context, IJwtGenerator jwtGenerator)
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
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
                Token = token
            };

            return Result<AuthDto>.Create(authDto);
        }
    }
}
