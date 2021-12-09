using System.Threading.Tasks;
using Application.Extensions;
using Application.Queries.Leaderboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class LeaderboardController : ApiControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = new GetLeaderboardQuery();

            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }
    }
}
