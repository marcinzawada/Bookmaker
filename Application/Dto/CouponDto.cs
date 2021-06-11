using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Dto
{
    public class CouponDto : IMapFrom<Coupon>
    {
        public int Id { get; set; }

        public decimal Bid { get; set; }

        public List<CouponBetValueDto> CouponBetValues { get; set; }

        public decimal TotalCourse { get; set; }
    }
}
