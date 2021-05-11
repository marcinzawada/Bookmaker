using System.Collections.Generic;
using System.Linq;
using ApiFootball.BetTypes;
using ApiFootball.BetTypes.DoubleChanceType;
using ApiFootball.BetTypes.DoubleChanceType.Generators;
using Domain.Entities;
using Xunit;

namespace UnitTests.ExternalAPIs.BetTypes.DoubleChanceType
{
    public class DoubleChanceSecondHalfGeneratorTests
    {
        [Fact]
        public void DoubleChanceSecondHalfGenerator_ValidDataShouldWork()
        {
            var bet = new Bet
            {
                Label = new Label
                {
                    ExtLabelId = 33
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

            var expected = new DoubleChanceSecondHalf
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

            var actual = new DoubleChanceSecondHalfGenerator(bet).GenerateBetType();

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
