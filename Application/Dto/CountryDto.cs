using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class CountryDto : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Flag { get; set; }

    }
}
