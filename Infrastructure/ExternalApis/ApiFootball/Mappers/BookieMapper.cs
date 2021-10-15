using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Bookies;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
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
    }
}
