using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Queries.Leaderboard;
using Infrastructure.BackgroundJobs.ApiFootballUpdater;
using Infrastructure.BackgroundJobs.CouponCheckers;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class LeaderboardController : ApiControllerBase
    {
        private readonly AppDbContext _context;
        private readonly BetsUpdater _betsUpdater;
        private readonly CouponChecker _couponChecker;
        private readonly FixtureUpdater _fixtureUpdater;

        public LeaderboardController(AppDbContext context, BetsUpdater betsUpdater, CouponChecker couponChecker, FixtureUpdater fixtureUpdater)
        {
            _context = context;
            _betsUpdater = betsUpdater;
            _couponChecker = couponChecker;
            _fixtureUpdater = fixtureUpdater;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //await _fixtureUpdater.Update();

            //await _couponChecker.Check();

            //await _betsUpdater.Update();

            //var cbv = await _context.CouponBetValues.ToListAsync();
            //_context.RemoveRange(cbv);
            //await _context.SaveChangesAsync();

            //var ci = await _context.ReadCouponItems.ToListAsync();
            //_context.RemoveRange(ci);
            //await _context.SaveChangesAsync();

            //var rc = await _context.ReadCoupons.ToListAsync();
            //_context.RemoveRange(rc);
            //await _context.SaveChangesAsync();

            //var c = await _context.Coupons.ToListAsync();
            //_context.RemoveRange(c);
            //await _context.SaveChangesAsync();

            //var b = await _context.PotentialBets
            //    .ToListAsync();
            //_context.RemoveRange(b);
            //await _context.SaveChangesAsync();

            //var lt = await _context.LeagueTeams.Where(x => x.LeagueId == 3497).ToListAsync();
            //_context.RemoveRange(lt);
            //await _context.SaveChangesAsync();

            //var t = await _context.Teams.ToListAsync();
            //_context.RemoveRange(t);
            //await _context.SaveChangesAsync();

            //var r = await _context.Rounds.Where(x => x.LeagueId == 3497).ToListAsync();
            //_context.RemoveRange(r);
            //await _context.SaveChangesAsync();

            //var lt = await _context.LeagueTeams.ToListAsync();
            //_context.RemoveRange(lt);
            //await _context.SaveChangesAsync();

            //var l = await _context.Leagues.ToListAsync();
            //_context.RemoveRange(l);
            //await _context.SaveChangesAsync();//deleted rounds and teams

            //var f = await _context.Fixtures.Where(x => x.LeagueId == 3497).ToListAsync();
            //_context.RemoveRange(f);
            //await _context.SaveChangesAsync();


            //var xd =  await _context.PotentialBets.ToListAsync();
            // _context.PotentialBets.RemoveRange(xd);
            // await _context.SaveChangesAsync();

            //var request = new GetLeaderboardQuery();

            //var response = await Mediator.Send(request);

            //var t = await _context.Teams.ToListAsync();
            //_context.RemoveRange(t);
            //await _context.SaveChangesAsync();

            //return this.CreateResponse(response);
            return Ok();
        }
    }
}
