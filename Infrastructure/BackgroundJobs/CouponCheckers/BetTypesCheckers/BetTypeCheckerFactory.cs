using System;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.BackgroundJobs.CouponCheckers.BetTypesCheckers
{
    public class BetTypeCheckerFactory
    {
        public BetTypeChecker CreateBetChecker(Label label, AppDbContext context)
        {
            switch (label.Name)
            {
                case "Match Winner":
                    return new MatchWinnerChecker(context);
                default:
                    throw new Exception($"No BetTypeCheckerFor {label.Name}");
            }
        }
    }
}
