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
        private readonly FixtureUpdater _fixtureUpdater;
        private readonly BetsUpdater _betsUpdater;
        private readonly CouponChecker _couponChecker;

        public CouponController(FixtureUpdater fixtureUpdater, BetsUpdater betsUpdater, CouponChecker couponChecker)
        {
            _fixtureUpdater = fixtureUpdater;
            _betsUpdater = betsUpdater;
            _couponChecker = couponChecker;
        }

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

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            //await _fixtureUpdater.Update();
            //await _betsUpdater.Update();
            await _couponChecker.Check();

            return Ok();
        }
    }
}
