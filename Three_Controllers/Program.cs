using Microsoft.EntityFrameworkCore;
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

        WebApplication_t app = builder.Build();
        using (IServiceScope scope = app.Services.CreateScope())
        {
            DatabaseContext context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            context.Database.Migrate();
        }

        app.MapControllers();
        app.Run();
    }
}
