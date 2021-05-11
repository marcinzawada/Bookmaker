using ApiFootball.DTOs.Bookies;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Data;
using Domain.Entities;

namespace ApiFootball.Mappers
{
    public class BookieMapper : BaseMapper, IDtoToModelMapper<BookieDto, Bookie>
    {
        public BookieMapper(AppDbContext context) : base(context)
        {
        }

        public Bookie MapDtoToModel(BookieDto dto)
        {
            return new Bookie
            {
                ExtBookmakerId = dto.Id,
                Name = dto.Name
            };
        }

        public List<Bookie> MapDtosToModels(List<BookieDto> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
