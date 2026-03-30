using ApiController_a = Microsoft.AspNetCore.Mvc.ApiControllerAttribute;
using Route_a = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGet_a = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPost_a = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpDelete_a = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using IActionResult_t = Microsoft.AspNetCore.Mvc.IActionResult;
using ControllerBase_t = Microsoft.AspNetCore.Mvc.ControllerBase;
using FromBody_a = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using OrderCreateDTO_t = NullPointersEtc.ThreeControllers.Models.OrderCreateDTO;
using OrderDTO_t = NullPointersEtc.ThreeControllers.Models.OrderDTO;
using Order_t = NullPointersEtc.ThreeControllers.Models.Order;
using IOrderService_t = NullPointersEtc.ThreeControllers.Services.IOrderService;
using Guid_t = System.Guid;

namespace NullPointersEtc.ThreeControllers.Controllers;


[type: ApiController_a, Route_a("api/Orders")]
public class OrdesController : ControllerBase_t
{
    public OrdesController(IOrderService_t orderService) =>
        myService = orderService;

    private readonly IOrderService_t myService;

    [method: HttpGet_a]
    public IActionResult_t GetAll() => Ok(myService.GetAll());

    [method: HttpGet_a(template: "{id}")]
    public IActionResult_t GetOrder(Guid_t id) => Ok(myService.GetById(id));

    [method: HttpPost_a]
    public IActionResult_t Create(
        [FromBody_a] OrderCreateDTO_t from)
    {
        ArgumentNullException.ThrowIfNull(from);
        Order_t order = new(from);
        myService.PlaceOrder(order);

        OrderDTO_t result = new(order);

        return CreatedAtAction(actionName: nameof(GetOrder),
            routeValues: new { Id = result.OrderID },
            value: result);
    }

    [method: HttpDelete_a]
    public IActionResult_t DeleteProduct() => NoContent();
}

