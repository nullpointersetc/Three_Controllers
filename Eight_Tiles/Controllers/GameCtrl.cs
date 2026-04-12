/*using ApiController_a = Microsoft.AspNetCore.Mvc.ApiControllerAttribute;
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

*/
using System;
using ApiController = Microsoft.AspNetCore.Mvc.ApiControllerAttribute;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpGet = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using IActionResult = Microsoft.AspNetCore.Mvc.IActionResult;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace NullPointersEtc.Eight_Tiles.Controllers
{
    public interface IGameService
    {
        IEnumerable<int> GetAll();
    }

    public class GameService : IGameService
    {
        public GameService() { }

        public IEnumerable<int> GetAll() => [1, 2, 3, 4];
    }

    [type: ApiController, Route("eighttiles")]
    public class GameController : ControllerBase
    {
        [method: HttpGet, Route("index.html")]
        public IActionResult Index()
        {
            string htmlContent = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>Inline HTML</title>
                    <meta charset='UTF-8'>
                </head>
                <body>
                    <h1>Hello from ASP.NET Core!</h1>
                    <table style=""border: 1px solid;"">
<tbody>
<tr><td style=""border: 1px solid;"">1</td>
<td style=""border: 1px solid;"">2</td>
<td style=""border: 1px solid;"">3</td><tr>
<tr><td style=""border: 1px solid;"">4</td>
<td style=""border: 1px solid;"">5</td>
<td style=""border: 1px solid;"">6</td><tr>
<tr><td style=""border: 1px solid;"">7</td>
<td style=""border: 1px solid;"">8</td>
<td></td><tr>
</tbody>
</table>
                </body>
                </html>";

            return new ContentResult
            {
                Content = htmlContent,
                ContentType = "text/html",
                StatusCode = 200
            };


        }
    }
}
