using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using IOrderService = NullPointersEtc.ThreeControllers.Services.IOrderService;
using IProductService = NullPointersEtc.ThreeControllers.Services.IProductService;
using IUserService = NullPointersEtc.ThreeControllers.Services.IUserService;
using OrderService = NullPointersEtc.ThreeControllers.Services.OrderService;
using ProductService = NullPointersEtc.ThreeControllers.Services.ProductService;
using UserService = NullPointersEtc.ThreeControllers.Services.UserService;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
using WebApplicationBuilder = Microsoft.AspNetCore.Builder.WebApplicationBuilder;
using DatabaseContext = NullPointersEtc.ThreeControllers.Data.Context;
using IServiceScope = Microsoft.Extensions.DependencyInjection.IServiceScope;
using GameController = NullPointersEtc.Eight_Tiles.Controllers.GameController;

namespace NullPointersEtc.ThreeControllers;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(options =>
                  options.UseSqlServer(
                      builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<GameController, GameController>();

        WebApplication app = builder.Build();
        using (IServiceScope scope = app.Services.CreateScope())
        {
            DatabaseContext context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            context.Database.EnsureCreated();
        }

        app.MapControllers();
        app.MapGet("", Index);
        app.MapGet("index.html", Index);
        app.Run();
    }

    public static void Index(Microsoft.AspNetCore.Http.HttpContext context)
    {
        GameController eightTiles = new GameController();

        ContentResult response = eightTiles.IndexDotHtml();

        context.Response.StatusCode =
            response.StatusCode.GetValueOrDefault(StatusCodes.Status200OK);

        context.Response.ContentType = response.ContentType;
        context.Response.WriteAsync(response.Content ?? "unexpectedly empty");
    }
}
