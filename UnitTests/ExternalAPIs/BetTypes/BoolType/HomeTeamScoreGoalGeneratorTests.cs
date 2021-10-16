using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Infrastructure.ExternalApis.ApiFootball.BetTypes;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.BoolType;
using Infrastructure.ExternalApis.ApiFootball.BetTypes.BoolType.Generators;
using Xunit;

namespace Api.Tests.ExternalAPIs.BetTypes.BoolType
{
    public class HomeTeamScoreGoalGeneratorTests
    {
        [Fact]
        public void HomeTeamScoreGoalGenerator_ValidDataShouldWork()
        {
            var bet = new PotentialBet
            {
                Label = new Label
                {
                    ExtLabelId = 43
                },
                BetValues = new List<BetValue>()
                {
                    new BetValue()
                    {
                        Id = 123,
                        Value = "Yes",
                        Odd = 4
                    },
                    new BetValue()
                    {
                        Id = 456,
                        Value = "No",
                        Odd = 12.74m
                    },
                }
            };

            var expected = new HomeTeamScoreGoal()
            {
                OddValues = new List<OddValue>
                {
                    new OddValue()
                    {
                        Id = 123,
                        Value = "Yes",
                        Odd = 4
                    },
                    new OddValue()
                    {
                        Id = 456,
                        Value = "No",
                        Odd = 12.74m
                    },
                }
            };

            var actual = new HomeTeamScoreGoalGenerator(bet).GenerateBetType();

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
