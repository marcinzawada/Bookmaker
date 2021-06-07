using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Account.Register;
using Application.Extensions;
using Application.Queries.Odds;
using Application.Queries.Odds.GetOdds;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using YamlDotNet.Core.Events;

namespace WebAPI.Controllers
{
    public class OddsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetOddsQuery query)
        {
            var response = await Mediator.Send(query);

            return this.CreateResponse(response);
        }
    }
}
