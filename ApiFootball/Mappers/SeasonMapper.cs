using Api.Data.Models;
using ApiFootball.DTOs.Seasons;
using Bookmaker.Api.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.Mappers
{
    class SeasonMapper : BaseMapper, IDtoToModelMapper<SeasonDto, Season>
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
    }
}
