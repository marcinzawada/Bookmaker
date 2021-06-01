using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.Mappers
{
    public interface IDtoToModelMapper<TDto, TModel>
    {
        public TModel MapDtoToModel(TDto dto);

        public List<TModel> MapDtosToModels(List<TDto> dtos)
        {
            var items = new List<TModel>();

            foreach (var teamDto in dtos)
            {
                items.Add(MapDtoToModel(teamDto));
            }

            return items;
        }

    }
}
