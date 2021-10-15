using System.Collections.Generic;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
{
    public interface IDtoToModelMapper<TDto, TModel>
    {
        public TModel MapDtoToModel(TDto dto);

        public List<TModel> MapDtosToModels(List<TDto> dtos)
        {
            var items = new List<TModel>();

            foreach (var dto in dtos)
            {
                items.Add(MapDtoToModel(dto));
            }

            return items;
        }

    }
}
