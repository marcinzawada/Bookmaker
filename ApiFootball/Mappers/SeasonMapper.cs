using Api.Data.Models;
using ApiFootball.DTOs.Seasons;
using Bookmaker.Api.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.Mappers
{
    public class SeasonMapper : BaseMapper, IDtoToModelMapper<SeasonDto, Season>
    {
        public SeasonMapper(AppDbContext context) : base(context)
        {
        }

        public Season MapDtoToModel(SeasonDto dto)
        {
            return new Season
            {
                Year = dto.Year
            };
        }

        public List<Season> MapDtosToModels(List<SeasonDto> dtos)
        {
            var seasons = new List<Season>();

            foreach (var seasonDto in dtos)
            {
                seasons.Add(MapDtoToModel(seasonDto));
            }

            return seasons;
        }
    }
}
