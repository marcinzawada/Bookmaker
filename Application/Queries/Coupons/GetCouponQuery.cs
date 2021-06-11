using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Queries.Coupons
{

    public record GetCouponQuery(int CouponId) : IRequest<Response>;

    public class RequestValidator : AbstractValidator<GetCouponQuery>
    {
        public RequestValidator()
        {
            RuleFor(x => x.CouponId)
                .NotEmpty().NotNull().GreaterThanOrEqualTo(1);
        }
    }

}
