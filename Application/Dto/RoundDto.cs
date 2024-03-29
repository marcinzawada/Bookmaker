﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class RoundDto : IMapFrom<Round>
    {
        public int Id { get; init; }

        public string Name { get; init; }
    }
}
