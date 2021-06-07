using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class TeamDto : IMapFrom<Team>
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Code { get; init; }

        public string Logo { get; init; }

        public bool IsNational { get; init; }
    }
}
