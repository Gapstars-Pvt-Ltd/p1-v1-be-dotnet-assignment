

using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
    {
        public CreateAirportCommandValidator()
        {
            RuleFor(c => c.Code).NotEmpty().Length(3);
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}