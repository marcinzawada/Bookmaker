using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Account.AddTokens;
using Application.Commands.Account.Login;
using Application.Commands.Account.Register;
using Application.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AccountController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var response = await Mediator.Send(command);

            return this.CreateResponse(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var response = await Mediator.Send(command);

            return this.CreateResponse(response);
        }

        [Authorize]
        [HttpPost("addTokens")]
        public async Task<IActionResult> AddTokens()
        {
            var command = new AddTokensCommand();

            var response = await Mediator.Send(command);

            return this.CreateResponse(response);
        }
    }
}
