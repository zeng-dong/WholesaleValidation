using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WholesaleValidation.Sales.Commands;

namespace WholesaleValidation.Sales.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return request.Product;
        }
    }
}
