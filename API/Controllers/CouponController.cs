using System.Threading.Tasks;
using Application.Commands.Coupons;
using Application.Extensions;
using Application.Queries.Coupons;
using Infrastructure.BackgroundJobs.ApiFootballUpdater;
using Infrastructure.BackgroundJobs.CouponCheckers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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


        [HttpGet("{couponId:int}")]
        public async Task<IActionResult> Get(int couponId)
        {
            var request = new GetCouponQuery(couponId);

            var response = await Mediator.Send(request);

            return this.CreateResponse(response);
        }
    }
}
