﻿using ApiFootball.DTOs.Labels;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Data;
using Domain.Entities;

namespace ApiFootball.Mappers
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