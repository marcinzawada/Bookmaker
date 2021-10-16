using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Odds;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
{
    public class BetMapper : BaseMapper
    {
        private readonly ILogger<BetMapper> _logger;

        public BetMapper(AppDbContext context, ILogger<BetMapper> logger) : base(context)
        {
            _logger = logger;
        }

        public List<PotentialBet> MapOddDtosToBets(List<OddDto> dtos)
        {
            var leagueIdFromDto = dtos.First().Fixture.LeagueId;
            var league = _context.Leagues.FirstOrDefault(x => x.ExtLeagueId == leagueIdFromDto);
            if (league == null)
                throw new EntityNotFoundException($"League not found. ExtLeagueId: {leagueIdFromDto}");

            var fixtureIds = dtos.Select(x => x.Fixture.FixtureId).Distinct();
            var fixturesInBase = _context.Fixtures.Where(x => fixtureIds.Contains(x.ExtFixtureId)).ToList();
            if (fixtureIds.Count() != fixturesInBase.Count())
            {
                var missingFixtureIds = fixtureIds.Except(fixturesInBase.Select(x => x.ExtFixtureId));
                throw new EntityNotFoundException($"Fixtures not found. ExtFixtureIds: " + string.Join(", ", missingFixtureIds));
            }

            //var bookieIds = dto.Bookies.Select(x => x.BookieId);
            var bookieIds = dtos.SelectMany(x => x.Bookies)
                .Select(y => y.BookieId).Distinct();

            var bookiesInBase =
                _context.Bookies.Where(x =>
                    bookieIds.Contains(x.ExtBookmakerId)).ToList();

            if (bookieIds.Count() != bookiesInBase.Count)
            {
                var missingBookieIds = bookieIds.Except(bookiesInBase.Select(x => x.ExtBookmakerId));
                throw new EntityNotFoundException($"Bookies not found. ExtBookieIds: " + string.Join(", ", missingBookieIds));
            }

            var labelIds =
                dtos.SelectMany(x => x.Bookies)
                    .SelectMany(y => y.Bets)
                    .Select(z => z.LabelId).Distinct();
            
            //dtos.Bookies.SelectMany(x => x.Bets)
                    //.Select(y => y.LabelId).Distinct();

            var labelsInBase =
                _context.Labels.Where(x =>
                    labelIds.Contains(x.ExtLabelId)).ToList();

            if (labelIds.Count() != labelsInBase.Count)
            {
                var missingLabelIds = labelIds.Except(labelsInBase.Select(x => x.ExtLabelId));
                throw new EntityNotFoundException($"Labels not found. ExtBookieIds: " + string.Join(", ", missingLabelIds));
            }

            //fixture.UpdatedBetsAt = DateTimeOffset.FromUnixTimeSeconds(dto.Fixture.UpdateAt).UtcDateTime;

            //var newBet = new Bet
            //{
            //    LeagueId = league.Id,
            //    //FixtureId = fixture.Id,
            //    Fixture = fixture,
            //    //UpdatedAt = DateTimeOffset.FromUnixTimeSeconds(dto.Fixture.UpdateAt).UtcDateTime
            //};

            var newBets = new List<PotentialBet>();

            foreach (var dto in dtos)
            {
                var fixtureFromBase = fixturesInBase.FirstOrDefault(x =>
                    x.ExtFixtureId == dto.Fixture.FixtureId);

                var updatedAt = DateTimeOffset.FromUnixTimeSeconds(dto.Fixture.UpdateAt).UtcDateTime;
                fixtureFromBase.UpdatedBetsAt = updatedAt;

                foreach (var bookie in dto.Bookies)
                {
                    // for every bet and bookmaker from api is one Bet in base
                    foreach (var bet in bookie.Bets)
                    {
                        var newBet = new PotentialBet
                        {
                            LeagueId = league.Id,
                            Fixture = fixtureFromBase
                        };

                        var bookieFromBase = bookiesInBase.FirstOrDefault(x =>
                            x.ExtBookmakerId == bookie.BookieId);

                        newBet.BookieId = bookieFromBase.Id;

                        var labelFromBase = labelsInBase.FirstOrDefault(x =>
                            x.ExtLabelId == bet.LabelId);

                        newBet.LabelId = labelFromBase.Id;


                        foreach (var betValue in bet.BetValues)
                        {
                            var oddIsValid = decimal.TryParse(betValue.Odd, NumberStyles.Any,
                                CultureInfo.InvariantCulture, out var parsedOdd);
                            if (!oddIsValid)
                            {
                                _logger.LogError(
                                    $"Odd isn't valid. ExtLeagueId: {dto.Fixture.LeagueId}," +
                                    $" ExtFixtureId: {dto.Fixture.FixtureId}," +
                                    $" ExtLabelId: {bet.LabelId}," +
                                    $" Value: {betValue.Value}, Odd: {betValue.Odd}");
                            }

                            if (oddIsValid)
                            {
                                newBet.BetValues.Add(new BetValue
                                {
                                    Odd = parsedOdd,
                                    Value = betValue.Value
                                });
                            }

                            newBets.Add(newBet);
                        }
                    }
                }
            }

            return newBets;
        }
    }
}
