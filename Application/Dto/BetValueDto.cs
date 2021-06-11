using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class BetValueDto : IMapFrom<BetValue>
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public decimal Odd { get; set; }

        public BetDto Bet { get; set; }

    }
}
