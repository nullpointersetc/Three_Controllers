using Microsoft.EntityFrameworkCore;
using NullPointersEtc.ThreeControllers.Data;
using NullPointersEtc.ThreeControllers.Models;
using NullPointersEtc.ThreeControllers.Services;
 
using DatabaseContext = NullPointersEtc.ThreeControllers.Data.Context;
using Product_t = NullPointersEtc.ThreeControllers.Models.Product;
using Guid_t = System.Guid;
 
namespace NullPointersEtc.ThreeControllers.Tests.Services;

public class ProductServiceTests : IDisposable
{
    private readonly DatabaseContext myContext;
    private readonly ProductService mySystemUnderTest;

    public ProductServiceTests()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: Guid_t.NewGuid().ToString()) // fresh DB per test
            .Options;

        myContext = new DatabaseContext(options);
        mySystemUnderTest = new ProductService(myContext);
    }

    public void Dispose()
    {
        myContext.Database.EnsureDeleted();
        myContext.Dispose();
    }

    // -------------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------------

    private static Product_t MakeProduct(string name = "Test Product", decimal price = 9.99m) =>
        new Product_t
        {
            ID = Guid_t.NewGuid(),
            Name = name,
            Price = price
        };

    private void Seed(params Product_t[] products)
    {
        myContext.Products.AddRange(products);
        myContext.SaveChanges();
    }

    // -------------------------------------------------------------------------
    // GetAll
    // -------------------------------------------------------------------------

    [Fact]
    public void GetAll_WhenNoProducts_ReturnsEmptyList()
    {
        var result = mySystemUnderTest.GetAll();

        Assert.Empty(result);
    }

    [Fact]
    public void GetAll_WhenProductsExist_ReturnsAllProducts()
    {
        Seed(MakeProduct("Alpha"), MakeProduct("Beta"), MakeProduct("Gamma"));

        var result = mySystemUnderTest.GetAll();

        Assert.Equal(3, result.Count());
    }

    // -------------------------------------------------------------------------
    // GetById
    // -------------------------------------------------------------------------

    [Fact]
    public void GetById_WhenProductExists_ReturnsCorrectProduct()
    {
        var product = MakeProduct("Widget");
        Seed(product);

        var result = mySystemUnderTest.GetById(product.ID);

        Assert.NotNull(result);
        Assert.Equal(product.ID, result.ID);
        Assert.Equal("Widget", result.Name);
    }

    [Fact]
    public void GetById_WhenProductDoesNotExist_ReturnsNull()
    {
        var result = mySystemUnderTest.GetById(Guid_t.NewGuid());

        Assert.Null(result);
    }

    // -------------------------------------------------------------------------
    // Create
    // -------------------------------------------------------------------------

    [Fact]
    public void Create_AddsProductToDatabase()
    {
        var product = MakeProduct("New Product");

        mySystemUnderTest.Create(product);

        var stored = myContext.Products.FirstOrDefault(p => p.ID == product.ID);
        Assert.NotNull(stored);
        Assert.Equal("New Product", stored.Name);
    }

    [Fact]
    public void Create_IncrementsProductCount()
    {
        Seed(MakeProduct());

        mySystemUnderTest.Create(MakeProduct("Second Product"));

        Assert.Equal(2, myContext.Products.Count());
    }

    // -------------------------------------------------------------------------
    // Update
    // -------------------------------------------------------------------------

    [Fact]
    public void Update_PersistsChangesToDatabase()
    {
        var product = MakeProduct("Old Name", 5.00m);
        Seed(product);

        product.Name = "New Name";
        product.Price = 19.99m;
        mySystemUnderTest.Update(product);

        var stored = myContext.Products.First(p => p.ID == product.ID);
        Assert.Equal("New Name", stored.Name);
        Assert.Equal(19.99m, stored.Price);
    }

    [Fact]
    public void Update_DoesNotChangeProductCount()
    {
        var product = MakeProduct();
        Seed(product);

        product.Name = "Updated";
        mySystemUnderTest.Update(product);

        Assert.Equal(1, myContext.Products.Count());
    }

    // -------------------------------------------------------------------------
    // Delete
    // -------------------------------------------------------------------------

    [Fact]
    public void Delete_WhenProductExists_RemovesFromDatabase()
    {
        var product = MakeProduct();
        Seed(product);

        mySystemUnderTest.Delete(product.ID);

        Assert.Null(myContext.Products.FirstOrDefault(p => p.ID == product.ID));
    }

    [Fact]
    public void Delete_WhenProductExists_DecrementsProductCount()
    {
        var toDelete = MakeProduct("Remove Me");
        var toKeep = MakeProduct("Keep Me");
        Seed(toDelete, toKeep);

        mySystemUnderTest.Delete(toDelete.ID);

        Assert.Equal(1, myContext.Products.Count());
    }

    [Fact]
    public void Delete_WhenProductDoesNotExist_DoesNotThrow()
    {
        Seed(MakeProduct());

        var exception = Record.Exception(() => mySystemUnderTest.Delete(Guid_t.NewGuid()));

        Assert.Null(exception);
        Assert.Equal(1, myContext.Products.Count()); // nothing removed
    }
}

