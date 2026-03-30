namespace NullPointersEtc.ThreeControllers.Controllers;

using ApiController_a = Microsoft.AspNetCore.Mvc.ApiControllerAttribute;
using Route_a = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGet_a = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPost_a = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpDelete_a = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using IActionResult_t = Microsoft.AspNetCore.Mvc.IActionResult;
using ControllerBase_t = Microsoft.AspNetCore.Mvc.ControllerBase;
using FromBody_a = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using UserDTO_t = NullPointersEtc.ThreeControllers.Models.UserDTO;
using UserCreateDTO_t = NullPointersEtc.ThreeControllers.Models.UserCreateDTO;
using User_t = NullPointersEtc.ThreeControllers.Models.User;
using IUserService_t =NullPointersEtc.ThreeControllers.Services.IUserService;
using Guid_t = System.Guid;

[type: ApiController_a, Route_a("api/Users")]
public class UsersController : ControllerBase_t
{
    public UsersController(IUserService_t userService) =>
        myService = userService;

    private readonly IUserService_t myService;

    [method: HttpGet_a]
    public IActionResult_t GetAll() => Ok(myService.GetAll());

    [method: HttpGet_a(template: "{id}")]
    public IActionResult_t GetUser(Guid_t id) => Ok(myService.GetById(id));

    [method: HttpPost_a]
    public IActionResult_t Create(
        [FromBody_a] UserCreateDTO_t from)
    {
        ArgumentNullException.ThrowIfNull(from);

        User_t user = new(from);
        myService.Add(user);

        UserDTO_t result = new(user);

        return CreatedAtAction(actionName: nameof(GetUser),
            routeValues: new { Id = user.ID },
            value: result);
    }

    [method: HttpDelete_a(template: "{id}")]
    public IActionResult_t DeleteProduct(Guid_t id)
    {
        myService.Delete(id);
        return Ok();
    }
}
