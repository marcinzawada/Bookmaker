using System.Collections.Generic;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class ClubDto : IMapFrom<Club>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfMembers { get; set; }

        public List<UserDto> Users { get; set; }

        public int AdminId { get; set; }
    }
}
