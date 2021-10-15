using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Fixtures.Rounds;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
{
    public class RoundMapper : BaseMapper, IDtoToModelMapper<RoundDto, Round>
    {
        public RoundMapper(AppDbContext context) : base(context)
        {
        }

        public Round MapDtoToModel(RoundDto dto)
        {
            var league = _context.Leagues.FirstOrDefault(x => x.ExtLeagueId == dto.ExtLeagueId);
            var name = dto.Name.Replace("_", " ");
            return new Round
            {
                Name = name,
                LeagueId = league?.Id ?? 0
            };
        }

        public List<Round> MapDtosToModels(List<RoundDto> dtos)
        {
            var rounds = new List<Round>();

            foreach (var roundDto in dtos)
            {
                rounds.Add(MapDtoToModel(roundDto));
            }

            return rounds;
        }
    }
}
