using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Mvc;


namespace Application.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult CreateResponse(this ControllerBase controller, Response response)
        {
            if (response.HttpStatus == HttpStatusCode.Created)
            {
                var createdResponse = (CreatedResponse)response;
                return controller.Created(createdResponse.ResourcePath, response);
            }

            return controller.StatusCode((int)response.HttpStatus, response);
        }

    }
}
