using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto
{
    public class OddDto : IMapFrom<Odd>
    {
        public int Id { get; init; }

        public int LeagueId { get; init; }

        public LeagueDto League { get; init; }

        public int FixtureId { get; init; }

        public FixtureDto Fixture { get; init; }
    }
}
