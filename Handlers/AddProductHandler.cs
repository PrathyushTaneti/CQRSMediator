using CQRSMediator.Commands;

namespace CQRSMediator.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product> // unit is a void in mediatR
    {
        private readonly ProxyDataStorage proxyDataStorage;

        public AddProductHandler(ProxyDataStorage proxyDataStorage) => this.proxyDataStorage = proxyDataStorage;

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await this.proxyDataStorage.AddProduct(request.product);
            return request.product; // default value for unit
        }
    }
}
