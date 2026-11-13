namespace Catalog.API.Products.CreateProduct
{
    public record CreateProcaductRequest(string Name, string Description, decimal Price, int StockQuantity, string Category);
    public record CreateProductResponse(Guid ProductId);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           app.MapPost("/products",async (CreateProcaductRequest request,ISender sender) =>
           {
              
               // Implementation for creating product and ssccscscsc
               var command = request.Adapt<CreateProductCommand>();
               var result = await sender.Send(command);
               var response = result.Adapt<CreateProductResponse>();
               return Results.Created($"/products/{response.ProductId}", response);
           })
                
                .WithDescription("Create a new product")
                .WithSummary("Create a new product")
                .WithTags("Products")
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest);
            

        }
    }
}
