using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.BackgroundJobs.CouponCheckers.BetTypesCheckers
{
    class MatchWinnerChecker : BetTypeChecker
    {
        public MatchWinnerChecker(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public override async Task<bool> Check(BetValue betValue)
        {
            var bet = await _context.PotentialBets
                .Include(x => x.Fixture)
                .ThenInclude(x => x.Score)
                .FirstOrDefaultAsync(x => x.Id == betValue.BetId);

            if (bet == null)
                throw new Exception($"Bet with id: {betValue.BetId} is null");

            var betOptionText = betValue.Value;

            var isOptionCorrect = Enum.TryParse(betOptionText, true, out MatchWinnerOption betOption);

            if (!isOptionCorrect)
            {
                throw new Exception(
                    $"Value \"{betOptionText}\" isn't correct and cannot be parsed to {typeof(MatchWinnerOption)}");
            }

            var fixture = bet.Fixture;
            var league = await _context.Leagues.FirstOrDefaultAsync(x => x.Id == bet.Fixture.LeagueId);
            if (league == null)
                throw new Exception($"League with id: {bet.Fixture.LeagueId} is null");

            var score = bet.Fixture.Score;

            if (score.GoalsHomeTeam == null || score.GoalsAwayTeam == null)
                throw new Exception($"Score for {fixture.Id} is empty, cannot be checked");

            if (league.Type == LeagueType.LEAGUE)
                return CheckMatchWinner((int)score.GoalsHomeTeam, (int)score.GoalsAwayTeam, betOption);

            if (score.PenaltyHomeGoals != null && score.PenaltyAwayGoals != null )
                return CheckMatchWinner((int)score.PenaltyHomeGoals, (int)score.PenaltyAwayGoals, betOption);

            if (score.ExtraTimeHomeGoals != null && score.ExtraTimeAwayGoals != null)
                return CheckMatchWinner((int)score.ExtraTimeHomeGoals, (int)score.ExtraTimeHomeGoals, betOption);

            return CheckMatchWinner((int)score.GoalsHomeTeam, (int)score.GoalsAwayTeam, betOption);
        }

        private bool CheckMatchWinner(int goalsHome, int goalsAway, MatchWinnerOption betOption)
        {
            if (goalsHome > goalsAway)
                return betOption == MatchWinnerOption.HOME;

            if (goalsHome < goalsAway)
                return betOption == MatchWinnerOption.AWAY;

            return betOption == MatchWinnerOption.DRAW;
        }

        public override async Task<bool> CheckIsMatchAlreadyFinished(BetValue betValue)
        {
            var bet = await _context.PotentialBets
                .Include(x => x.Fixture)
                .FirstOrDefaultAsync(x => x.Id == betValue.BetId);

            if (bet == null)
                throw new Exception($"Bet with id: {betValue.BetId} is null");

            var fixture = bet.Fixture;

            return fixture.Status == MatchStatus.FT;
        }
    }
}
