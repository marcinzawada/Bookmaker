using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.Coupon
{
    public class MakeCouponRequest
    {
        [Required]
        public decimal Bid { get; set; }

        [Required] 
        public List<int> BetValuesId { get; set; }
    }
}
