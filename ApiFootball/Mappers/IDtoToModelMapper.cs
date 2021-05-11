using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.Mappers
{
    public interface IDtoToModelMapper<TDto, TModel>
    {
        public TModel MapDtoToModel(TDto dto);

        public List<TModel> MapDtosToModels(List<TDto> dtos);

    }
}
