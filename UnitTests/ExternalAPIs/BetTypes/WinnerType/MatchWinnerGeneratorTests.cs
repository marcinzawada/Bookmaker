﻿using System;
using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.BetTypes;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.WinnerType.Generators;
using Newtonsoft.Json;
using Xunit;

namespace UnitTests.ExternalAPIs.BetTypes.WinnerType
{
    public class MatchWinnerGeneratorTests
    {
        [Fact]
        public void MatchWinnerGenerator_ValidDataShouldWork()
        {
            var bet = new PotentialBet
            {
                Label = new Label()
                {
                    ExtLabelId = 1
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

            var expected = new MatchWinner
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

            var actual = new MatchWinnerGenerator(bet).GenerateBetType();

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.Equal(expectedJson, actualJson);
        }

        [Fact]
        public void MatchWinnerGenerator_NullBetShouldFail()
        {
            Assert.Throws<ArgumentException>("Bet",
                () => new MatchWinnerGenerator(null).GenerateBetType());
        }

        [Fact]
        public void MatchWinnerGenerator_NullBetLabelShouldFail()
        {
            Assert.Throws<ArgumentException>("Bet.Label",
                () => new MatchWinnerGenerator(new PotentialBet()).GenerateBetType());
        }

        [Fact]
        public void MatchWinnerGenerator_NullBetValuesShouldFail()
        {
            var bet = new PotentialBet
            {
                Label = new Label(),
            };

            Assert.Throws<ArgumentException>("Bet.BetValues",
                () => new MatchWinnerGenerator(bet).GenerateBetType());
        }

        [Fact]
        public void MatchWinnerGenerator_InvalidExtLabelIdShouldFail()
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

            Assert.Throws<ArgumentException>("Bet.Label.ExtLabelId", 
                () => new MatchWinnerGenerator(bet).GenerateBetType());
        }
    }
}
