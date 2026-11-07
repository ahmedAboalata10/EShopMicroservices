using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price, int StockQuantity, string Category) : IRequest<CreateProductResponse>;
    public record CreateProductResponse(Guid ProductId);
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        public Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
