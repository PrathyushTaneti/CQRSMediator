using CQRSMediator.Queries;

namespace CQRSMediator.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ProxyDataStorage proxyDataStorage;

        public GetProductByIdHandler(ProxyDataStorage proxyDataStorage)
        {
            this.proxyDataStorage = proxyDataStorage;
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return this.proxyDataStorage.GetProductById(request.Id);
        }
    }
}
