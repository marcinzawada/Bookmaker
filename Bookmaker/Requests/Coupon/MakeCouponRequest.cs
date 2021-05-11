using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmaker.Requests.Coupon
{
    public class MakeCouponRequest
    {
        [Required]
        public decimal Bid { get; set; }

        [Required] 
        public List<int> BetValuesId { get; set; }
    }
}
