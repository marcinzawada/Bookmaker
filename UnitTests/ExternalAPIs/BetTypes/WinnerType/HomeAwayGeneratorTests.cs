using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.BetTypes;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType.Generators;
using Newtonsoft.Json;
using Xunit;

namespace UnitTests.ExternalAPIs.BetTypes.WinnerType
{
    public class HomeAwayGeneratorTests
    {
        [Fact]
        public void HomeAwayGenerator_ValidDataShouldWork()
        {
            var bet = new PotentialBet
            {
                Label = new Label()
                {
                    ExtLabelId = 2
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
                        Value = "Away",
                        Odd = 0.77m
                    },
                }
            };

            var expected = new HomeAway
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
                        Value = "Away",
                        Odd = 0.77m
                    },
                }
            };

            var actual = new HomeAwayGenerator(bet).GenerateBetType();

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.Equal(expectedJson, actualJson);
        }
    }
}
