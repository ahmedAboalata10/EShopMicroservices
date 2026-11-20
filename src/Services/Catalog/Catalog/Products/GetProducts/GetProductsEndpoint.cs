namespace Catalog.API.Products.GetProducts
{
    public record GetProductsRequest : IRequest<GetProductsResponse>; 
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var query = new GetProductsQuery();
                var result = await sender.Send(query);
                var response =result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .WithTags("Products")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(statusCode: StatusCodes.Status400BadRequest)
            .WithDescription("Get all products")
            .WithSummary("Get all products");
        }
    }
}
