using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class BetDto : IMapFrom<PotentialBet>
    {
        public int Id { get; set; }

        public LabelDto Label { get; set; }

        public List<BetValueDto> BetValues { get; set; }
    }
}
