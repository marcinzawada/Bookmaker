using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.BetTypes;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.GoalsOverUnderType;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.GoalsOverUnderType.Generators;
using Newtonsoft.Json;
using Xunit;

namespace UnitTests.ExternalAPIs.BetTypes.GoalsOverUnderType
{
    public class GoalsOverUnderSecondHalfGeneratorTests
    {
        [Fact]
        public void GoalsOverUnderGenerator_ValidDataShouldWork()
        {
            var bet = new Bet
            {
                LabelId = 456,

                Label = new Label()
                {
                    ExtLabelId = 5
                },
                BetValues = new List<BetValue>()
                {
                    new BetValue()
                    {
                        Id = 123,
                        Value = "Over 0.5",
                        Odd = 4
                    },
                    new BetValue()
                    {
                        Id = 456,
                        Value = "Under 0.5",
                        Odd = 12.74m
                    },
                    new BetValue()
                    {
                        Id = 789,
                        Value = "Over 2.5",
                        Odd = 4.76m
                    },
                    new BetValue()
                    {
                        Id = 321,
                        Value = "Under 2.5",
                        Odd = 21.37m
                    },
                }
            };

            var expected = new GoalsOverUnderSecondHalf
            {
                OddId = 123,
                LabelId = 456,

                OddValues = new List<OddValue>()
                {
                    new OddValue()
                    {
                        Id = 123,
                        Value = "Over 0.5",
                        Odd = 4
                    },
                    new OddValue()
                    {
                        Id = 456,
                        Value = "Under 0.5",
                        Odd = 12.74m
                    },
                    new OddValue()
                    {
                        Id = 789,
                        Value = "Over 2.5",
                        Odd = 4.76m
                    },
                    new OddValue()
                    {
                        Id = 321,
                        Value = "Under 2.5",
                        Odd = 21.37m
                    },
                }
            };

            var actual = new GoalsOverUnderGenerator(bet).GenerateBetType();

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.Equal(expectedJson, actualJson);
        }
    }
}
