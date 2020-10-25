using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFootball.Mappers
{
    public interface IDtoToModelMapper<in TDto, out TModel>
    {
        public TModel MapDtoToModel(TDto dto);
    }
}
