using System.Collections.Generic;
using System.Linq;
using Api.Data.Models;
using ApiFootball.BetTypes;
using ApiFootball.BetTypes.DoubleChanceType;
using ApiFootball.BetTypes.DoubleChanceType.Generators;
using ApiFootball.BetTypes.ExactScoreType;
using ApiFootball.BetTypes.ExactScoreType.Generators;
using Xunit;

namespace Api.Tests.ExternalAPIs.BetTypes.DoubleChanceType
{
    public class DoubleChanceFirstHalfGeneratorTests
    {
        [Fact]
        public void DoubleChanceFirstHalfGenerator_ValidDataShouldWork()
        {
            var bet = new Bet
            {
                Label = new Label
                {
                    ExtLabelId = 20
                },
                BetValues = new List<BetValue>()
                {
                    new BetValue()
                    {
                        Id = 123,
                        Value = "Home/Draw",
                        Odd = 4
                    },
                    new BetValue()
                    {
                        Id = 456,
                        Value = "Home/Away",
                        Odd = 12.74m
                    },
                    new BetValue()
                    {
                        Id = 789,
                        Value = "Draw/Away",
                        Odd = 0.77m
                    },
                }
            };

            var expected = new DoubleChanceFirstHalf
            {
                OddValues = new List<OddValue>
                {
                    new OddValue()
                    {
                        Id = 123,
                        Value = "Home/Draw",
                        Odd = 4
                    },
                    new OddValue()
                    {
                        Id = 456,
                        Value = "Home/Away",
                        Odd = 12.74m
                    },
                    new OddValue()
                    {
                        Id = 789,
                        Value = "Draw/Away",
                        Odd = 0.77m
                    },
                }
            };

            var actual = new DoubleChanceFirstHalfGenerator(bet).GenerateBetType();

            foreach (var item in expected.OddValues)
            {
                var itemInActual = actual.OddValues.FirstOrDefault(
                    x => x.Value == item.Value && x.Odd == item.Odd
                                               && x.Id == item.Id);

                Assert.True(itemInActual != null);
            }
        }
    }
}
