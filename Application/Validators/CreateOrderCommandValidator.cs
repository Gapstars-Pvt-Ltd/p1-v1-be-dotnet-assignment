

using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.Quantity).GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.FlightRateId).NotEmpty();
        }
    }
}