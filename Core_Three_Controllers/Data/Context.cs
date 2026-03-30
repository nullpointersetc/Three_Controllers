#region "Context.cs"
using Order_t = NullPointersEtc.ThreeControllers.Models.Order;
using Product_t = NullPointersEtc.ThreeControllers.Models.Product;
using User_t = NullPointersEtc.ThreeControllers.Models.User;
using DbContext_t = Microsoft.EntityFrameworkCore.DbContext;
using DbContextOptions_t = Microsoft.EntityFrameworkCore.DbContextOptions
    <NullPointersEtc.ThreeControllers.Data.Context>;
using DbSetOfProduct_t = Microsoft.EntityFrameworkCore.DbSet
    <NullPointersEtc.ThreeControllers.Models.Product>;
using DbSetOfOrder_t = Microsoft.EntityFrameworkCore.DbSet
    <NullPointersEtc.ThreeControllers.Models.Order>;
using DbSetOfUser_t = Microsoft.EntityFrameworkCore.DbSet
    <NullPointersEtc.ThreeControllers.Models.User>;

namespace NullPointersEtc.ThreeControllers.Data;

public class Context : DbContext_t
{
    public Context(DbContextOptions_t options) : base(options) { }
    public DbSetOfProduct_t Products { get => this.Set<Product_t>(); }
    public DbSetOfUser_t Users { get => this.Set<User_t>(); }
    public DbSetOfOrder_t Orders { get => this.Set<Order_t>(); }
}

#endregion "Context.cs"

