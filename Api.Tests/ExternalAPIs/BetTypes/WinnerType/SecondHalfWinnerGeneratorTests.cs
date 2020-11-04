using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Models;
using ApiFootball.BetTypes;
using ApiFootball.BetTypes.WinnerType;
using Newtonsoft.Json;
using Xunit;

namespace Api.Tests.ExternalAPIs.BetTypes.WinnerType
{
    public class SecondHalfWinnerGeneratorTests
    {
        [Fact]
        public void SecondHalfWinnerGenerator_ValidDataShouldWork()
        {
            var bet = new Bet
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
