namespace CQRSMediator.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
