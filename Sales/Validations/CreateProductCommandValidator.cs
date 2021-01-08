using FluentValidation;
using WholesaleValidation.Sales.Commands;

namespace WholesaleValidation.Sales.Validations
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Product.Code).NotEmpty();
            RuleFor(c => c.Product.Name).MaximumLength(10).NotEmpty();
        }
    }
}
