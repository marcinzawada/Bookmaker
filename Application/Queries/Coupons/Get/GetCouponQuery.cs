using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Queries.Coupons.Get
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
