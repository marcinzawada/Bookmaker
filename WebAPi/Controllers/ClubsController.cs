﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Clubs.AddUser;
using Application.Commands.Clubs.Create;
using Application.Commands.Clubs.Leave;
using Application.Extensions;
using Application.Queries.Clubs.Get;
using Application.Queries.Clubs.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class ClubsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClubCommand request)
        {
            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserToClubCommand request)
        {
            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllClubsQuery(); 

            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }

        [HttpGet("{clubId:int}")]
        public async Task<IActionResult> Get(int clubId)
        {
            var request = new GetClubQuery(clubId);

            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }

        [HttpDelete("{clubId:int}/user")]
        public async Task<IActionResult> Leave(int clubId)
        {
            var request = new LeaveClubCommand(clubId);

            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }
    }
}