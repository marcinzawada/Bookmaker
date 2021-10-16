using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.BetTypes;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.ExactScoreType.Generators;
using Xunit;

namespace UnitTests.ExternalAPIs.BetTypes.ExactScoreType
{
    public class ExactScoreFirstHalfGeneratorTests
    {
        [Fact]
        public void ExactScoreFirstHalfGenerator_ValidDataShouldWork()
        {
            var bet = new PotentialBet
            {
                Label = new Label
                {
                    ExtLabelId = 31
                },
                BetValues = new List<BetValue>()
                {
                    new BetValue()
                    {
                        Id = 123,
                        Value = "0:0",
                        Odd = 4
                    },
                    new BetValue()
                    {
                        Id = 456,
                        Value = "2:1",
                        Odd = 12.74m
                    },
                    new BetValue()
                    {
                        Id = 789,
                        Value = "1:2",
                        Odd = 0.77m
                    },
                    new BetValue()
                    {
                        Id = 987,
                        Value = "7:5",
                        Odd = 4
                    },
                    new BetValue()
                    {
                        Id = 654,
                        Value = "3:9",
                        Odd = 12.74m
                    },
                    new BetValue()
                    {
                        Id = 321,
                        Value = "4:2",
                        Odd = 0.77m
                    },
                }
            };

            var expected = new ExactScoreFirstHalf
            {
                OddValues = new List<OddValue>
                {
                    new OddValue()
                    {
                        Id = 123,
                        Value = "0:0",
                        Odd = 4
                    },
                    new OddValue()
                    {
                        Id = 456,
                        Value = "2:1",
                        Odd = 12.74m
                    },
                    new OddValue()
                    {
                        Id = 789,
                        Value = "1:2",
                        Odd = 0.77m
                    },
                    new OddValue()
                    {
                        Id = 987,
                        Value = "7:5",
                        Odd = 4
                    },
                    new OddValue()
                    {
                        Id = 654,
                        Value = "3:9",
                        Odd = 12.74m
                    },
                    new OddValue()
                    {
                        Id = 321,
                        Value = "4:2",
                        Odd = 0.77m
                    },
                }
            };

            var actual = new ExactScoreFirstHalfGenerator(bet).GenerateBetType();

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
