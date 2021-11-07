using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
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

        public RegisterCommandHandler(IPasswordHasher<User> passwordHasher, IDbContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User()
            {
                Email = request.Email.ToLower().Trim(),
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, request.Password);
            newUser.PasswordHash = hashedPassword;

            await _context.Users.AddAsync(newUser, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Response.Success();
        }
    }
}
