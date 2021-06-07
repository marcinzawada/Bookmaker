using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class FixtureDto : IMapFrom<Fixture>
    {
        public int Id { get; init; }

        public int LeagueId { get; init; }

        public LeagueDto League { get; init; }

        public int? RoundId { get; init; }

        public RoundDto Round { get; init; }

        public int HomeTeamId { get; init; }

        public TeamDto HomeTeam { get; init; }

        public int AwayTeamId { get; init; }

        public TeamDto AwayTeam { get; init; }

    }
}
