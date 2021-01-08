using FluentValidation;

namespace WholesaleValidation.Sales.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(model => model.Name).NotEmpty();
        }
    }
}
