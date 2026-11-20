namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger _logger;
        public GetProductsQueryHandler(IDocumentSession session ,ILogger<GetProductsQueryHandler> logger)
        {
            _session = session;
            _logger = logger;
        }
        public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetProductsQuery {0}", request );
            var products = await _session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }

}
