namespace NullPointersEtc.Three_Controllers
{
    using Microsoft.EntityFrameworkCore;
    using IOrderService = NullPointersEtc.Three_Controllers.Services.IOrderService;
    using IProductService = NullPointersEtc.Three_Controllers.Services.IProductService;
    using IUserService = NullPointersEtc.Three_Controllers.Services.IUserService;
    using OrderService = NullPointersEtc.Three_Controllers.Services.OrderService;
    using ProductService = NullPointersEtc.Three_Controllers.Services.ProductService;
    using UserService = NullPointersEtc.Three_Controllers.Services.UserService;
    using WebApplication_t = Microsoft.AspNetCore.Builder.WebApplication;
    using WebApplicationBuilder_t = Microsoft.AspNetCore.Builder.WebApplicationBuilder;
    using DatabaseContext=NullPointersEtc.Three_Controllers.Data.DatabaseContext;
    using IServiceScope = Microsoft.Extensions.DependencyInjection.IServiceScope;
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
}
