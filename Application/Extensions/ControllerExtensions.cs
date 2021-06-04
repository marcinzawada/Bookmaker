using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Mvc;


namespace Application.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult CreateResponse(this ControllerBase controller, Response response)
            => controller.StatusCode((int)response.HttpStatus, response);

    }
}
