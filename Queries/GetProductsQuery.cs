namespace CQRSMediator.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
   
}
