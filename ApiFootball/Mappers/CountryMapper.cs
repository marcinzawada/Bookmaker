using Api.Data.Models;
using ApiFootball.DTOs.Countries;
using Bookmaker.Api.Data.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.Mappers
{
    class CountryMapper : BaseMapper, IDtoToModelMapper<CountryDto, Country>
    {
        public CountryMapper(AppDbContext context) : base(context)
        {
        }

        public Country MapDtoToModel(CountryDto dto)
        {
            return new Country
            {
                Name = dto.Name,
                Code = dto.Code,
                Flag = dto.Flag
            };
        }
    }
}
