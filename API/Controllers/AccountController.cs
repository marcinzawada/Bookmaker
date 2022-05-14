using System.Threading.Tasks;
using Application.Commands.Account.ChangePassword;
using Application.Commands.Account.Login;
using Application.Commands.Account.Register;
using Application.Commands.Account.ResetPassword;
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
        [HttpGet("game-tokens")]
        public async Task<IActionResult> RefreshGameTokens()
        {
            var command = new AddTokensCommand();

            var response = await Mediator.Send(command);

            return this.CreateResponse(response);
        }

        [HttpPost("password-reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);

            return this.CreateResponse(response);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            var response = await Mediator.Send(command);

            return this.CreateResponse(response);
        }
    }
}
