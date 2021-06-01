using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using ApiFootball.DTOs.Odds;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiFootball.Mappers
{
    public class OddMapper : BaseMapper, IDtoToModelMapper<OddDto, Odd>
    {
        private readonly ILogger<OddMapper> _logger;

        public OddMapper(AppDbContext context, ILogger<OddMapper> logger) : base(context)
        {
            _logger = logger;
        }

        public Odd MapDtoToModel(OddDto dto)
        {
            var league = _context.Leagues.FirstOrDefault(x => x.ExtLeagueId == dto.Fixture.LeagueId);
            if (league == null)
                throw new EntityNotFoundException($"League not found. ExtLeagueId: {dto.Fixture.LeagueId}");

            var fixture = _context.Fixtures.FirstOrDefault(x => x.ExtFixtureId == dto.Fixture.FixtureId);
            if (fixture == null)
                throw new EntityNotFoundException($"Fixture not found. ExtFixtureId: {dto.Fixture.FixtureId}");

            var bookieIds = dto.Bookies.Select(x => x.BookieId);

            var bookiesInBase =
                _context.Bookies.Where(x =>
                    bookieIds.Contains(x.ExtBookmakerId)).ToList();

            if (bookieIds.Count() != bookiesInBase.Count)
                throw new EntityNotFoundException($"Some bookies not found. ExtBookieIds: " + string.Join(", ", bookieIds));

            var labelIds =
                dto.Bookies.SelectMany(x => x.Bets)
                    .Select(y => y.LabelId).Distinct();

            var labelsInBase =
                _context.Labels.Where(x =>
                    labelIds.Contains(x.ExtLabelId)).ToList();

            if (labelIds.Count() != labelsInBase.Count)
                throw new EntityNotFoundException($"Some labels not found. ExtBookieIds: " + string.Join(", ", labelIds));

            var newOdd = new Odd
            {
                LeagueId = league.Id,
                FixtureId = fixture.Id,
                UpdatedAt = DateTimeOffset.FromUnixTimeSeconds(dto.Fixture.UpdateAt).UtcDateTime
            };

            var bets = new List<Bet>();

            foreach (var bookie in dto.Bookies)
            {
                // for every bet and bookmaker from api is one Bet in base
                foreach (var bet in bookie.Bets)
                {
                    var newBet = new Bet();

                    var bookieFromBase = bookiesInBase.FirstOrDefault(x =>
                        x.ExtBookmakerId == bookie.BookieId);

                    newBet.BookieId = bookieFromBase.Id;

                    var labelFromBase = labelsInBase.FirstOrDefault(x =>
                        x.ExtLabelId == bet.LabelId);

                    newBet.LabelId = labelFromBase.Id;

                    foreach (var betValue in bet.BetValues)
                    {
                        var oddIsValid = decimal.TryParse(betValue.Odd, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedOdd);
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

                    }

                    bets.Add(newBet);
                }
            }

            newOdd.Bets = bets;

            return newOdd;
        }
    }
}
