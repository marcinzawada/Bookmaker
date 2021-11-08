using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.BackgroundJobs.CouponCheckers.BetTypesCheckers
{
    public abstract class BetTypeChecker
    {
        protected readonly AppDbContext _context;

        protected BetTypeChecker(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public abstract Task<bool> Check(BetValue betValue);

        public abstract Task<bool> CheckIsMatchAlreadyFinished(BetValue betValue);
    }
}
