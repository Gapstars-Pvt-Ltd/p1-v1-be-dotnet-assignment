using API.Application.Commands;
using FluentValidation;

namespace API.Application.Validators;

public class CreateOrderValidators : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidators()
    {
        RuleFor(r => r.OrderDto.PassengerInfo)
            .NotEmpty()
            .WithMessage("You need to have a customer.")
            .DependentRules(() =>
            {
                RuleFor(e => e.OrderDto.PassengerInfo.firstName).NotEmpty().WithMessage("You need to have a first name.");
                RuleFor(e => e.OrderDto.PassengerInfo.lastName).NotEmpty().WithMessage("You need to have a last name.");
                RuleFor(e => e.OrderDto.PassengerInfo.Age).NotEmpty().WithMessage("You need to have an age.");
                RuleFor(e => e.OrderDto.PassengerInfo.email).NotEmpty().WithMessage("You need to have an email.");
            });
           
        RuleFor(r => r.OrderDto.OrderItems)
            .NotNull()
            .WithMessage("You need to have at least one booking.")
            .DependentRules(() =>
            {
                RuleForEach(e => e.OrderDto.OrderItems).NotEmpty().WithMessage("You need to have at least one booking.");
            });
    }
}