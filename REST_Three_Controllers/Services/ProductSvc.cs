using DatabaseContext = NullPointersEtc.ThreeControllers.Data.Context;
using Product_t = NullPointersEtc.ThreeControllers.Models.Product;
using Guid_t = System.Guid;

namespace NullPointersEtc.ThreeControllers.Services;

public interface IProductService
{
    IEnumerable<Product_t> GetAll();
    Product_t? GetById(Guid_t id);
    void Create(Product_t product);
    void Update(Product_t product);
    void Delete(Guid_t id);
}

public class ProductService : IProductService
{
    public ProductService(DatabaseContext context) =>
        myContext = context;

    private readonly DatabaseContext myContext;

    public IEnumerable<Product_t> GetAll() =>
        myContext.Products.ToList();

    public Product_t? GetById(Guid_t id) =>
        myContext.Products.FirstOrDefault(p => p.ID == id);

    public void Create(Product_t product)
    {
        myContext.Products.Add(product);
        myContext.SaveChanges();
    }

    public void Update(Product_t product)
    {
        myContext.Products.Update(product);
        myContext.SaveChanges();
    }

    public void Delete(Guid_t id)
    {
        Product_t? product =
            myContext.Products.FirstOrDefault(p => p.ID == id);

        if (product is not null)
        {
            myContext.Products.Remove(product);
            myContext.SaveChanges();
        }
    }
}