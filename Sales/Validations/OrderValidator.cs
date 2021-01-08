using FluentValidation;

namespace WholesaleValidation.Sales.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(m => m.CustomerName)
                //.Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10)

                ;

            RuleFor(model => model.Price).InclusiveBetween(1, 10);

            RuleFor(m => m.CustomerEmail).EmailAddress();

            RuleFor(m => m.OrderStatus).IsInEnum();

            // nested validator
            RuleFor(model => model.Product)
                .NotNull()
                .SetValidator(new ProductValidator());

            // collection
            RuleForEach(model => model.MoreProducts)
                .SetValidator(new ProductValidator());
        }
    }
}
