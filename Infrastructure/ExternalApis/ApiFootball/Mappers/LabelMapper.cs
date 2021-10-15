using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.ExternalApis.ApiFootball.Dtos.Labels;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
{
    public class LabelMapper : BaseMapper, IDtoToModelMapper<LabelDto, Label>
    {
        public LabelMapper(AppDbContext context) : base(context)
        {
        }

        public Label MapDtoToModel(LabelDto dto)
        {
            return new Label
            {
                ExtLabelId = dto.Id,
                Name = dto.Name
            };
        }

        public List<Label> MapDtosToModels(List<LabelDto> dtos)
        {
            var labels = new List<Label>();

            foreach (var labelDto in dtos)
            {
                labels.Add(MapDtoToModel(labelDto));
            }

            return labels;
        }
    }
}
