using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Data.Models;
using ApiFootball.BetTypes;
using ApiFootball.BetTypes.BoolType;
using ApiFootball.BetTypes.BoolType.Generators;
using Xunit;

namespace Api.Tests.ExternalAPIs.BetTypes.BoolType
{
    public class CleanSheetHomeGeneratorTests
    {
        [Fact]
        public void CleanSheetHomeGenerator_ValidDataShouldWork()
        {
            var bet = new Bet
            {
                Label = new Label
                {
                    ExtLabelId = 27
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

            var expected = new CleanSheetAway()
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

            var actual = new CleanSheetHomeGenerator(bet).GenerateBetType();

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
