using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.BetTypes;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType.Generators;
using Newtonsoft.Json;
using Xunit;

namespace UnitTests.ExternalAPIs.BetTypes.WinnerType
{
    public class SecondHalfWinnerGeneratorTests
    {
        [Fact]
        public void SecondHalfWinnerGenerator_ValidDataShouldWork()
        {
            var bet = new PotentialBet
            {
                Label = new Label()
                {
                    ExtLabelId = 3
                },
                BetValues = new List<BetValue>()
                {
                    new BetValue()
                    {
                        Value = "Home",
                        Odd = 4
                    },
                    new BetValue()
                    {
                        Value = "Draw",
                        Odd = 12.74m
                    },
                    new BetValue()
                    {
                        Value = "Away",
                        Odd = 0.77m
                    },
                }
            };

            var expected = new SecondHalfWinner()
            {
                OddValues = new List<OddValue>
                {
                    new OddValue()
                    {
                        Value = "Home",
                        Odd = 4
                    },
                    new OddValue()
                    {
                        Value = "Draw",
                        Odd = 12.74m
                    },
                    new OddValue()
                    {
                        Value = "Away",
                        Odd = 0.77m
                    },
                }
            };

            var actual = new SecondHalfWinnerGenerator(bet).GenerateBetType();

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.Equal(expectedJson, actualJson);
        }
    }
}
