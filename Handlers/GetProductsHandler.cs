using CQRSMediator.Models;
using CQRSMediator.Queries;

namespace CQRSMediator.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ProxyDataStorage proxyDataStorage;

        public GetProductsHandler(ProxyDataStorage proxyDataStorage) => this.proxyDataStorage = proxyDataStorage;
        
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)  => await proxyDataStorage.GetAllProducts();
    }
}
