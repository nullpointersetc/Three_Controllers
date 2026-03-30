using ApiController_a = Microsoft.AspNetCore.Mvc.ApiControllerAttribute;
using Route_a = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGet_a = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPost_a = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpDelete_a = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using IActionResult_t = Microsoft.AspNetCore.Mvc.IActionResult;
using ControllerBase_t = Microsoft.AspNetCore.Mvc.ControllerBase;
using FromBody_a = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using ProductDTO_t = NullPointersEtc.ThreeControllers.Models.ProductDTO;
using ProductCreateDTO_t = NullPointersEtc.ThreeControllers.Models.ProductCreateDTO;
using IProductService_t = NullPointersEtc.ThreeControllers.Services.IProductService;
using Product_t = NullPointersEtc.ThreeControllers.Models.Product;
using Guid_t = System.Guid;
namespace NullPointersEtc.ThreeControllers.Controllers;

[type: ApiController_a, Route_a("api/Products")]
public class ProductsController : ControllerBase_t
{
    public ProductsController(IProductService_t productService) =>
        myService = productService;

    private readonly IProductService_t myService;

    [method: HttpGet_a]
    public IActionResult_t GetAll() => Ok(myService.GetAll());

    [method: HttpGet_a(template: "{id}")]
    public IActionResult_t GetProduct(Guid_t id)
        => Ok(myService.GetById(id));

    [method: HttpPost_a]
    public IActionResult_t Create(
        [FromBody_a] ProductCreateDTO_t from)
    {
        ArgumentNullException.ThrowIfNull(from);

        Product_t product = new(from);
        myService.Create(product);

        ProductDTO_t result = new(product);

        return CreatedAtAction(actionName: nameof(GetProduct),
                routeValues: new { Id = product.ID },
                value: result);
    }

    [method: HttpDelete_a(template: "{id}")]
    public IActionResult_t DeleteProduct(Guid_t id)
    {
        myService.Delete(id);
        return Ok();
    }
}
