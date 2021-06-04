using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Constants;
using Application.Common.JWT;
using Application.Models;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.Account.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtGenerator _jwtGenerator;


        public LoginCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetSingleByEmail(request.Email, cancellationToken);

            if (user is null)
                return Response.Failure(Errors.InvalidCredentials);

            var passwordCheckResult = _passwordHasher.VerifyHashedPassword(
                user, user.PasswordHash, request.Password);

            if (passwordCheckResult == PasswordVerificationResult.Failed)
                return Response.Failure(Errors.InvalidCredentials);

            var token = _jwtGenerator.Generate(user);

            var loginDto = new LoginDto
            {
                Id = user.Id,
                Token = token
            };

            return Result<LoginDto>.Create(loginDto);
        }
    }
}
