using Order_t = NullPointersEtc.ThreeControllers.Models.Order;
using Product_t = NullPointersEtc.ThreeControllers.Models.Product;
using User_t = NullPointersEtc.ThreeControllers.Models.User;

namespace NullPointersEtc.ThreeControllers.Data
{
    using DbContext_t = Microsoft.EntityFrameworkCore.DbContext;
    using DbContextOptions_t =
        Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext>;
    using DbSetOfProduct_t = Microsoft.EntityFrameworkCore.DbSet<Product_t>;
    using DbSetOfOrder_t = Microsoft.EntityFrameworkCore.DbSet<Order_t>;
    using DbSetOfUser_t = Microsoft.EntityFrameworkCore.DbSet<User_t>;

    public class DatabaseContext : DbContext_t
    {
        public DatabaseContext(DbContextOptions_t options) : base(options) { }
        public DbSetOfProduct_t Products { get => this.Set<Product_t>(); }
        public DbSetOfUser_t Users { get => this.Set<User_t>(); }
        public DbSetOfOrder_t Orders { get => this.Set<Order_t>(); }
    }
}

