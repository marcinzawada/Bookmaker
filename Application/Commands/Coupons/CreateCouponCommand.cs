using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Commands.Coupons
{
    public record CreateCouponCommand(List<int> BetValueIds, decimal Bid) : IRequest<Response>;

    public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
    {
        public CreateCouponCommandValidator()
        {
            RuleFor(x => x.BetValueIds)
                .NotNull().NotEmpty();

            RuleFor(x => x.Bid)
                .NotNull().NotEmpty()
                .GreaterThanOrEqualTo(1)
                .Custom((bid, context) =>
                {
                    var validDecimalNumbers = new List<int> {0, 1, 2};

                    int decimals = BitConverter.GetBytes(decimal.GetBits(bid)[3])[2];
                    if (!validDecimalNumbers.Contains(decimals))
                    {
                        context.AddFailure("Bid", 
                            "Bid must has 0, 1, or 2 decimals.");
                    }
                });
        }
    }
}
