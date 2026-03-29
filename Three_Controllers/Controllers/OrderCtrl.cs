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
    using OrderDTO_t = NullPointersEtc.Three_Controllers.Models.OrderDTO;
    using Order_t = NullPointersEtc.Three_Controllers.Models.Order;
    using IOrderService_t= NullPointersEtc.Three_Controllers.Services.IOrderService;

    [type: ApiController_a, Route_a("api/Orders")]
    public class OrdesController : ControllerBase_t
    {
        public OrdesController(IOrderService_t orderService) =>
            _orderService = orderService;

        private readonly IOrderService_t _orderService;

        [method: HttpGet_a]
        public IActionResult_t GetAll() => Ok(_orderService.GetAll());

        [method: HttpGet_a(template: "{id}")]
        public IActionResult_t GetOrder(int id) => Ok(_orderService.GetById(id));

        [method: HttpPost_a]
        public IActionResult_t Create(
            [FromBody_a] OrderDTO_t order)
        {
            ArgumentNullException.ThrowIfNull(order);
            _orderService.PlaceOrder(Order_t.From(order));

            return CreatedAtAction(actionName: nameof(GetOrder),
                routeValues: new { Id = order.Id },
                value: order);
        }

        [method: HttpDelete_a]
        public IActionResult_t DeleteProduct() => NoContent();
    }
}

