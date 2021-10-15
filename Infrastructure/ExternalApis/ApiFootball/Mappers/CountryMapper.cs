using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Countries;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
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
