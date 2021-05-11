﻿using ApiFootball.DTOs.Countries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Data;
using Domain.Entities;

namespace ApiFootball.Mappers
{
    public class CountryMapper : BaseMapper, IDtoToModelMapper<CountryDto, Country>
    {
        public CountryMapper(AppDbContext context) : base(context)
        {
        }

        public Country MapDtoToModel(CountryDto dto)
        {
            return new Country
            {
                Name = dto.Country,
                Code = dto.Code,
                Flag = dto.Flag
            };
        }

        public List<Country> MapDtosToModels(List<CountryDto> dtos)
        {
            var countries = new List<Country>();

            foreach (var countryDto in dtos)
            {
                countries.Add(MapDtoToModel(countryDto));
            }

            return countries;
        }
    }
}