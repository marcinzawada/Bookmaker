using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Queries.Bets.GetBets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BetsController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetBetsQuery request)
        {
            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }
    }
}
