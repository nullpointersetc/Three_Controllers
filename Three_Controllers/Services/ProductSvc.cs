namespace NullPointersEtc.Three_Controllers.Services
{
    using DatabaseContext = NullPointersEtc.Three_Controllers.Data.DatabaseContext;
    using Product_t = NullPointersEtc.Three_Controllers.Models.Product;

    public interface IProductService
    {
        IEnumerable<Product_t> GetAll();
        Product_t? GetById(int id);
        void Create(Product_t product);
        void Update(Product_t product);
        void Delete(int id);
    }

    public class ProductService : IProductService
    {
        public ProductService(DatabaseContext context) { m_context = context; }
        private readonly DatabaseContext m_context;

        public IEnumerable<Product_t> GetAll() => m_context.Products.ToList();

        public Product_t? GetById(int id) => m_context.Products.FirstOrDefault(p => p.Id == id);

        public void Create(Product_t product)
        {
            m_context.Products.Add(product);
            m_context.SaveChanges();
        }

        public void Update(Product_t product)
        {
            m_context.Products.Update(product);
            m_context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = m_context.Products.FirstOrDefault(p => p.Id == id);
            if (product is not null)
            {
                m_context.Products.Remove(product);
                m_context.SaveChanges();
            }
        }
    }
}