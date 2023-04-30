namespace CQRSMediator.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;
}
