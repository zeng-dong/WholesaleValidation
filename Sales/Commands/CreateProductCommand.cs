using MediatR;

namespace WholesaleValidation.Sales.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
