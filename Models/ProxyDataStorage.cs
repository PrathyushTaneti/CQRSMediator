namespace CQRSMediator.Models
{
    public class ProxyDataStorage
    {
        private static List<Product> products;

        public ProxyDataStorage()
        {
            products = new List<Product>() {
                new Product{Id = 1, Name = "Product 1"},
                new Product{Id = 2, Name = "Product 2"},
                new Product{Id = 3, Name = "Product 3"},
                new Product{Id = 4, Name = "Product 4"}
            };
        }

        public async Task AddProduct(Product product)
        {
            products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.FromResult(products);
        }

        public async Task<Product> GetProductById(int Id) => 
            await Task.FromResult(products.Single(product => product.Id == Id));
    }
}
