using CQRSMediator.Commands;
using CQRSMediator.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator; // Imediator interface helps us to interact with the mediatr

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = this.mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            var productReturn = await this.mediator.Send(new AddProductCommand(product));
            return CreatedAtRoute("GetProductById", new { Id = productReturn.Id }, productReturn);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult> GetProductById(int Id)
        {
            var product = await this.mediator.Send(new GetProductByIdQuery(Id));
            return Ok(product);
        }
    }
}
