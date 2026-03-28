namespace NullPointersEtc.Three_Controllers
{
    using WebApplicationBuilder_t = Microsoft.AspNetCore.Builder.WebApplicationBuilder;
    using WebApplication_t = Microsoft.AspNetCore.Builder.WebApplication;

    using ProductService =     NullPointersEtc.Three_Controllers.Services.ProductService;
    using IProductService = NullPointersEtc.Three_Controllers.Services.IProductService;
    using OrderService = NullPointersEtc.Three_Controllers.Services.OrderService;
    using IOrderService = NullPointersEtc.Three_Controllers.Services.IOrderService;
    using UserService = NullPointersEtc.Three_Controllers.Services.UserService;
    using IUserService = NullPointersEtc.Three_Controllers.Services.IUserService;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder_t builder = WebApplication_t.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<IOrderService, OrderService>();
            builder.Services.AddSingleton<IUserService, UserService>();

            WebApplication_t app = builder.Build();
            app.MapControllers();
            app.Run();
        }
    }
}
