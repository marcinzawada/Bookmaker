using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookmaker.Requests.Coupon;
using Microsoft.AspNetCore.Mvc;

namespace Bookmaker.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CouponController : ControllerBase
    {
        public IActionResult MakeCoupon(MakeCouponRequest request)
        {
            return Ok();
        }
    }
}
