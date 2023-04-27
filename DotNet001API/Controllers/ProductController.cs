using Azure.Core;
using DotNet001API.Commands;
using DotNet001API.Models;
using DotNet001API.Queries;
using DotNet001Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MimeTypes;
using Product = DotNet001Shared.Models.Product;
namespace DotNet001API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/")]
    [ApiController]
    public class ProductController : Controller
    {

        IMediator Mediator { get; set; }

        public ProductController(IMediator mediator)
        {
            Mediator = mediator;
           
        }


        [HttpGet("getproducts")]
        public async Task<LocalResponse<Product>> GetProducts([FromQuery] ProductRequest request)
        {
            var result = await Mediator.Send(new GetProductsQuery
            {
                Search = request.Search
            });

            return result;
        }

        [HttpGet("getproducts/{id}")]
        public async Task<OperationObjectResponse<Product>> GetProductsById(int id)
        {
            OperationObjectResponse<Product> result = await Mediator.Send(new GetProductQuery
            {
                Id = id
            });

            return result;
        }

        [HttpPost("addproducts")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await Mediator.Send(new AddProductCommand(product));

            return Ok(result);
        }

        [HttpDelete("deleteproducts/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await Mediator.Send(new DeleteProductCommand(id));

            return Ok();
        }

        [HttpPut("updateproducts/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, int id)
        {
            await Mediator.Send(new UpdateProductCommand(product, id));

            return Ok();
        }

    }
}
