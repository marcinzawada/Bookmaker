using System.Threading.Tasks;
using Application.Commands.Coupons;
using Application.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CouponController : ApiControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(CreateCouponCommand request)
        {
            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }
    }
}
