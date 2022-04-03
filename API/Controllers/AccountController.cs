using System.Threading.Tasks;
using Application.Commands.Account.Login;
using Application.Commands.Account.Register;
using Application.Extensions;
using Application.Queries.Account.RefreshTokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
        [HttpGet("refreshGameTokens")]
        public async Task<IActionResult> RefreshGameTokens()
        {
            var command = new AddTokensCommand();

            var response = await Mediator.Send(command);

            return this.CreateResponse(response);
        }
    }
}
