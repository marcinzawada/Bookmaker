using API.Requests.Coupon;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
