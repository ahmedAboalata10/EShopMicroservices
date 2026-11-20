
namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price, int StockQuantity, string Category) : ICommand<CreateProductResult>;
public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Product description is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required.");
    }
}
public record CreateProductResult(Guid ProductId);
public class CreateProductHandler (IDocumentSession session ,ILogger<CreateProductHandler> logger): ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new product: {Name}, {Description}, {Price}, {StockQuantity}, {Category}", request.Name, request.Description, request.Price, request.StockQuantity, request.Category);
        var product = new Product
        {   
            //Id = Guid.NewGuid(),???
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            StockQuantity = request.StockQuantity,
            Category = request.Category
        };

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        return new CreateProductResult(product.Id);
    }
}
