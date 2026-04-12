using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StatusCodes= Microsoft.AspNetCore.Http.StatusCodes;
using IOrderService = NullPointersEtc.ThreeControllers.Services.IOrderService;
using IProductService = NullPointersEtc.ThreeControllers.Services.IProductService;
using IUserService = NullPointersEtc.ThreeControllers.Services.IUserService;
using OrderService = NullPointersEtc.ThreeControllers.Services.OrderService;
using ProductService = NullPointersEtc.ThreeControllers.Services.ProductService;
using UserService = NullPointersEtc.ThreeControllers.Services.UserService;
using WebApplication_t = Microsoft.AspNetCore.Builder.WebApplication;
using WebApplicationBuilder_t = Microsoft.AspNetCore.Builder.WebApplicationBuilder;
using DatabaseContext = NullPointersEtc.ThreeControllers.Data.Context;
using IServiceScope = Microsoft.Extensions.DependencyInjection.IServiceScope;
using IGameService = NullPointersEtc.Eight_Tiles.Controllers.IGameService;
using GameService = NullPointersEtc.Eight_Tiles.Controllers.GameService;

namespace NullPointersEtc.ThreeControllers;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder_t builder = WebApplication_t.CreateBuilder(args);

        builder.Services.AddDbContext<DatabaseContext>(options =>
                  options.UseSqlServer(
                      builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IGameService, GameService>();

        WebApplication_t app = builder.Build();
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
        context.Response.StatusCode = StatusCodes.Status200OK;
        context.Response.ContentType = "text/html";
        context.Response.WriteAsync("<!DOCTYPE html>\n"+
                "<html>\n"+
                "<head>\n"+
                    "<title>Inline HTML</title>\n"+
                    "<meta charset='UTF-8'>\n"+
                "</head>\n"+
                "<body>\n"+
                    "<h1>Hello from ASP.NET Core!</h1>\n"+
                    "<p><a href=\"eighttiles/index.html\">Link</a></p>\n"+
                "</body>\n"+
                "</html>\n");
    }
}
