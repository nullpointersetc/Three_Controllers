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
    using UserDTO_t = NullPointersEtc.Three_Controllers.Models.UserDTO;
    using User_t = NullPointersEtc.Three_Controllers.Models.User;
    using IUserService_t =NullPointersEtc.Three_Controllers.Services.IUserService;

    [type: ApiController_a, Route_a("api/Users")]
    public class UsersController : ControllerBase_t
    {
        public UsersController(IUserService_t userService) => _userService = userService;

        private readonly IUserService_t _userService;

        [method: HttpGet_a]
        public IActionResult_t GetAll() => Ok(_userService.GetAll());

        [method: HttpGet_a(template: "{id}")]
        public IActionResult_t GetUser(int id) => Ok(_userService.GetById(id));

        [method: HttpPost_a]
        public IActionResult_t Create(
            [FromBody_a] UserDTO_t user)
        {
            ArgumentNullException.ThrowIfNull(user);

            _userService.Add(User_t.From(user));

            return CreatedAtAction(actionName: nameof(GetUser),
                routeValues: new { Id = user.Id },
                value: user);
        }

        [method: HttpDelete_a]
        public IActionResult_t DeleteProduct() => NoContent();
    }
}
