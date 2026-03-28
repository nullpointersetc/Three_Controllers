namespace NullPointersEtc.Three_Controllers.Controllers
{
    using ApiController_a = Microsoft.AspNetCore.Mvc.ApiControllerAttribute;
    using Route_a = Microsoft.AspNetCore.Mvc.RouteAttribute;
    using HttpGet_a = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
    using HttpPost_a = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
    using HttpDelete_a = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
    using IActionResult_t = Microsoft.AspNetCore.Mvc.IActionResult;
    using ControllerBase_t = Microsoft.AspNetCore.Mvc.ControllerBase;
    using FromBody_a = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
    using ProductDTO_t = NullPointersEtc.Three_Controllers.Models.ProductDTO;
    using IProductService_t = NullPointersEtc.Three_Controllers.Services.IProductService;

    [type: ApiController_a, Route_a("api/Products")]
    public class ProductsController : ControllerBase_t
    {
        public ProductsController(IProductService_t productService) =>
            _productService = productService;

        private readonly IProductService_t _productService;

        [method: HttpGet_a]
        public IActionResult_t GetAll() => Ok(_productService.GetAll());

        [method: HttpGet_a(template: "{id}")]
        public IActionResult_t GetProduct(int id) => Ok(_productService.GetById(id));

        [method: HttpPost_a]
        public IActionResult_t Create(
            [FromBody_a] ProductDTO_t product)
        {
            ArgumentNullException.ThrowIfNull(product);
            _productService.Create(product);

            return CreatedAtAction(actionName: nameof(GetProduct),
                    routeValues: new { Id = 1 },
                    value: product);
        }

        [method: HttpDelete_a]
        public IActionResult_t DeleteProduct() => NoContent();
    }
}
