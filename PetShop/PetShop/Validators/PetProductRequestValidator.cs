using FluentValidation;
using PetShop.Models.Requests;


namespace PetShop.Validators
{
    public class PetProductRequestValidator : AbstractValidator<PetProductRequest>
    {
        public PetProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id must be greather than 0!");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("Name must be between 2 and 50 characters!");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Age must be greather than or equal to 0!");

            RuleFor(x => x.Type)
                .NotNull()
                .NotEmpty()
                .WithMessage("Type cannot be null or empty!");

            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0!");
        }
    }
}
